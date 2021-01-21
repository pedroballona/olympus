using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;

namespace Totvs.Olympus.Infrastructure.Adapter
{
  public static class AutoMapperQueryble
  {
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 20;

    public static IQueryResult<TDocument> Paginate<TDocument>(IEnumerable<TDocument> documents, PaginationOptions<TDocument> options)
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
        var orderQueryable = ascending ? documents.AsQueryable().OrderBy(selector) : documents.AsQueryable().OrderByDescending(selector);

        foreach (var (selectorThen, ascendingThen) in options.Sorting.Skip(1))
        {
          orderQueryable = ascendingThen ? orderQueryable.ThenBy(selectorThen) : orderQueryable.ThenByDescending(selectorThen);
        }
        documents = orderQueryable;
      }
      int page = options.Page ?? DefaultPage;
      int pageSize = options.PageSize ?? DefaultPageSize;
      int toSkip = (page - 1) * pageSize;
      List<TDocument> listResult = documents.Skip(toSkip).Take(pageSize + 1).ToList();
      var hasNext = listResult.Count >= (pageSize + 1);
      if (hasNext)
        listResult.RemoveAt(listResult.Count - 1);
      return new QueryResult<TDocument>(hasNext, listResult);

    }
    public static IQueryResult<TDocument> Paginate<TDocument>(IEnumerable<TDocument> documents, RequestAllOptionsDTO options)
    {
      return Paginate(documents, TotvsApiMongoAdapter.AdaptOptionsToMongo<TDocument>(options));
    }
  }
}
