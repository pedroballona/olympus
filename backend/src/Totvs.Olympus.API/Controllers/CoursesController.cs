using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;
using Totvs.Olympus.Domain.ExternalServices;
using Totvs.Olympus.Domain.Services;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly IGetAllCoursesFromAluraService _service;
    private readonly ICourseService _courseService;

    public CoursesController(IGetAllCoursesFromAluraService service,
                             ICourseService courseService)
    {
      _service = service;
      _courseService = courseService;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IEnumerable<BasicCourseDataDTO>> GetAllCourses()
    {
      var result = await _service.GetCourses();
      return result;
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<CourseDTO> InputCourse()
    {
      CourseDTO example = new CourseDTO()
      {
        Id = "123",
        Instructors = new List<string>() { "Otávio Olegário de Castro" },
        Rating = 5,
        Title = "Implementing MongoDB"
      };

      var result = await _courseService.CreateCourse(example);
      return result;
    }
  }
}
