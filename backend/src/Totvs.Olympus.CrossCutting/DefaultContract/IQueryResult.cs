using System.Collections.Generic;

namespace Totvs.Olympus.CrossCutting.DefaultContract
{
  public interface IQueryResult<out TDocument>
  {
    bool HasNext { get; }
    IReadOnlyList<TDocument> Items { get; }
  }
}
