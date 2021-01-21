using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;
using Totvs.Olympus.Domain.ExternalServices;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly IGetAllCoursesFromAluraService _service;

    public CoursesController(IGetAllCoursesFromAluraService service)
    {
      _service = service;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IEnumerable<BasicCourseDataDTO>> GetAllCourses()
    {
      var result = await _service.GetCourses();
      return result;
    }
  }
}
