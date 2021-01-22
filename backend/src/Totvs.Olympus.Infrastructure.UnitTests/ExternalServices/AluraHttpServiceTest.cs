using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.Enum;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;
using Totvs.Olympus.Infrastructure.ExternalServices;
using Xunit;
using static Totvs.Olympus.Infrastructure.UnitTests.UnitTestHelpers.BasicCourseDataDTOTestHelper;

namespace Totvs.Olympus.Infrastructure.UnitTests.ExternalServices
{
  public class AluraHttpServiceTest
  {
    private readonly AluraHttpService _service;
    private readonly Mock<HttpMessageHandler> _handlerMock;
    private readonly Mock<IHttpClientFactory> _httpClientFactory;
    private readonly HttpClient _httpClient;

    public AluraHttpServiceTest()
    {
      _handlerMock = new Mock<HttpMessageHandler>();
      _httpClient = new HttpClient(_handlerMock.Object);
      _httpClientFactory = new Mock<IHttpClientFactory>();
      _service = new AluraHttpService(_httpClientFactory.Object);
    }

    private void MockHttpClientFactory(HttpStatusCode code, object content)
    {
      _httpClient.BaseAddress = new Uri("https://alura.com.br"); ;

      _handlerMock.Protected()
                  .Setup<Task<HttpResponseMessage>>("SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                  .ReturnsAsync(new HttpResponseMessage
                  {
                    StatusCode = code,
                    Content = (content != null) ? WrapJsonContent(content) : default
                  });

      _httpClientFactory.Setup(h => h.CreateClient(It.Is<string>(n => n == nameof(EHttpClientNames.Alura))))
                        .Returns(_httpClient);
    }

    private HttpContent WrapJsonContent<T>(T content)
    {
      return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
    }

    [Fact]
    public async Task GivenSendRequest_WhenIsStatusCodeOk_ThenReturnsHttpStatusCodeAndRequestDto()
    {
      MockHttpClientFactory(HttpStatusCode.OK, new[] { GetBasicCourseDataDTO() });

      var result = await _service.SendRequest<object, IEnumerable<BasicCourseDataDTO>>(HttpMethod.Post,
                                                                                       "api/cursos", 
                                                                                       null);

      Assert.NotNull(result);
      Assert.IsAssignableFrom<IEnumerable<BasicCourseDataDTO>>(result);
    }
  }
}
