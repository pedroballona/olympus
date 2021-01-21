using System.Net.Http;
using System.Threading.Tasks;

namespace Totvs.Olympus.Domain.ExternalServices
{
  public interface IAluraHttpService
  {
    Task<ResponseDto> SendRequest<RequestDto, ResponseDto>(HttpMethod method, string url, RequestDto content);
  }
}
