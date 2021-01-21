using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Domain.Services;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly ICoursesRepository _repository;
    private readonly ICourseService _courseService;

    public CoursesController(ICoursesRepository repository,
                             ICourseService courseService)
    {
      _repository = repository;
      _courseService = courseService;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IQueryResult<CourseDTO>> GetAllCourses([FromQuery] RequestAllOptionsDTO optionsDTO)
    {
      var result = await _repository.GetAllPaginatedContracts(optionsDTO);
      return result;
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<CourseDTO> InputCourse()
    {
      CourseDTO example = new CourseDTO()
      {
        Id = "123",
        Title = "Implementing MongoDB"
      };

      var result = await _courseService.CreateCourse(example);
      return result;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<DetailCourseDTO> GetDetailCourse(string id)
    {
      var result = await _repository.GetDetailCourse(id);
      return result;
    }
  }
}
