using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
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
    private readonly ICourseMongoService _courseService;

    public CoursesController(ICoursesRepository repository,
                             ICourseMongoService courseService)
    {
      _repository = repository;
      _courseService = courseService;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IQueryResult<CourseDTO>> GetAllCourses([FromQuery] string filter, [FromQuery] RequestAllOptionsDTO optionsDTO)
    {
      var result = await _repository.GetAllPaginatedContracts(filter, optionsDTO);
      return result;
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<Course> InputCourse([FromBody] CourseInputDTO course)
    {
      var result = await _courseService.CreateCourse(course);
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
