using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Totvs.Olympus.CrossCutting.DefaultContract
{
  [ExcludeFromCodeCoverage]
  public class RequestAllOptionsDTO
  {
    [FromQuery(Name = "order")]
    public string Order { get; set; }

    [FromQuery(Name = "page")]
    public int? Page { get; set; }

    [FromQuery(Name = "pageSize")]
    public int? PageSize { get; set; }
  }
}
