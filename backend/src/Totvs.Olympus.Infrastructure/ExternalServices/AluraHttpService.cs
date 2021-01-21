using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.Enum;
using Totvs.Olympus.Domain.ExternalServices;

namespace Totvs.Olympus.Infrastructure.ExternalServices
{
  public class AluraHttpService : IAluraHttpService
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AluraHttpService(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseDto> SendRequest<RequestDto, ResponseDto>(HttpMethod method, string url, RequestDto content)
    {
      var response = await SendRequest(method, url, content);

      if (response.IsSuccessStatusCode)
      {
        return ParseResponseJson<ResponseDto>(await response.Content.ReadAsStringAsync());
      }
      else
      {
        return default(ResponseDto);
      }
    }

    private async Task<HttpResponseMessage> SendRequest<RequestDto>(HttpMethod method, string url, RequestDto content)
    {
      var httpClient = _httpClientFactory.CreateClient(nameof(EHttpClientNames.Alura));

      var requestUrl = new HttpRequestMessage(method, url);

      if (content != null)
        requestUrl.Content = WrapJsonContent(content);

      var response = await httpClient.SendAsync(requestUrl);
      return response;
    }

    private HttpContent WrapJsonContent<T>(T content)
    {
      return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
    }

    private T ParseResponseJson<T>(string responseJson)
    {
      return JsonConvert.DeserializeObject<T>(responseJson);
    }
  }
}
