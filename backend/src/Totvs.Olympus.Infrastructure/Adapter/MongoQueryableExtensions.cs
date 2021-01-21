using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.Infrastructure.Adapter;

namespace MongoDB.Driver.Linq
{
  public static class MongoQueryableExtensions
  {
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 20;

    public static async Task<IQueryResult<TDocument>> Paginate<TDocument>(this IMongoQueryable<TDocument> queryable, PaginationOptions<TDocument> options)
    {
      if (options == default)
      {
        options = new PaginationOptions<TDocument>()
        {
          Page = DefaultPage,
          PageSize = DefaultPageSize
        };
      }
      if (options.Sorting != default && options.Sorting.Any())
      {
        (var selector, var ascending) = options.Sorting.First();
        var orderQueryable = ascending ? queryable.OrderBy(selector) : queryable.OrderByDescending(selector);

        foreach (var (selectorThen, ascendingThen) in options.Sorting.Skip(1))
        {
          orderQueryable = ascendingThen ? orderQueryable.ThenBy(selectorThen) : orderQueryable.ThenByDescending(selectorThen);
        }
        queryable = orderQueryable;
      }
      int page = options.Page ?? DefaultPage;
      int pageSize = options.PageSize ?? DefaultPageSize;
      int toSkip = (page - 1) * pageSize;
      List<TDocument> listResult = await queryable.Skip(toSkip).Take(pageSize + 1).ToListAsync();
      var hasNext = listResult.Count >= (pageSize + 1);
      if (hasNext)
        listResult.RemoveAt(listResult.Count - 1);
      return new QueryResult<TDocument>(hasNext, listResult);
    }

    public static Task<IQueryResult<TDocument>> Paginate<TDocument>(this IMongoQueryable<TDocument> queryable, RequestAllOptionsDTO options)
    {
      return queryable.Paginate(TotvsApiMongoAdapter.AdaptOptionsToMongo<TDocument>(options));
    }
  }
}
