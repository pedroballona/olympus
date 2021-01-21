using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;
using Totvs.Olympus.Domain.ExternalServices;

namespace Totvs.Olympus.Infrastructure.ExternalServices
{
  public class GetAllCoursesFromAluraService : IGetAllCoursesFromAluraService
  {
    private string _coursesUrl = $"api/cursos";
    private readonly IAluraHttpService _service;

    public GetAllCoursesFromAluraService(IAluraHttpService service)
    {
      _service = service;
    }

    public async Task<IEnumerable<BasicCourseDataDTO>> GetCourses()
    {
      var response = await _service.SendRequest<object, IEnumerable<BasicCourseDataDTO>>(HttpMethod.Get,
                                                                                         _coursesUrl,
                                                                                         null);
      return response;
    }
  }
}
