using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Totvs.Olympus.CrossCutting.DefaultContract
{
  public class PaginationOptions<TDocument>
  {
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public IList<(Expression<Func<TDocument, object>> Selector, bool Ascending)> Sorting { get; set; }
  }
}
