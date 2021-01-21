using System;
using System.Collections.Generic;
using Totvs.Olympus.CrossCutting.DefaultContract;

namespace Totvs.Olympus.Infrastructure.Adapter
{
  public class QueryResult<TDocument> : IQueryResult<TDocument>
  {
    public bool HasNext { get; private set; }
    public IReadOnlyList<TDocument> Items { get; private set; }

    public QueryResult(bool hasNext, IReadOnlyList<TDocument> items)
    {
      this.HasNext = hasNext;
      this.Items = items ?? throw new ArgumentNullException(nameof(items));
    }

    public static QueryResult<TDocument> Empty()
    {
      return new QueryResult<TDocument>(false, new List<TDocument>());
    }
  }
}
