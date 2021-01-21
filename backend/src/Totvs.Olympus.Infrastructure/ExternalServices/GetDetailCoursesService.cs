using System.Net.Http;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;
using Totvs.Olympus.Domain.ExternalServices;

namespace Totvs.Olympus.Infrastructure.ExternalServices
{
  public class GetDetailCoursesService : IGetDetailCoursesService
  {
    private string _coursesDetailUrl = $"api/curso";
    private readonly IAluraHttpService _service;

    public GetDetailCoursesService(IAluraHttpService service)
    {
      _service = service;
    }

    public async Task<DetailCourseDataDto> GetDetailCourseData(string courseId)
    {
      var response = await _service.SendRequest<object, DetailCourseDataDto>(HttpMethod.Get,
                                                                             $"{_coursesDetailUrl}-{courseId}",
                                                                             null);
      return response;
    }
  }
}
