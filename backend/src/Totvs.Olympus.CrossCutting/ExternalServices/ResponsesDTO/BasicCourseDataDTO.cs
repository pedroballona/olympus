using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO
{
  [ExcludeFromCodeCoverage]
  public partial class BasicCourseDataDTO
  {
    [JsonProperty("tempo_estimado")]
    public long TempoEstimado { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("nome")]
    public string Nome { get; set; }
  }
}
