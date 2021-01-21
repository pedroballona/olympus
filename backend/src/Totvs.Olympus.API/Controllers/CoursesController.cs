using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.RepositoryContracts;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly ICoursesRepository _repository;

    public CoursesController(ICoursesRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IQueryResult<CourseDTO>> GetAllCourses()
    {
      var result = await _repository.GetAllPaginatedContracts();
      return result;
    }
  }
}
