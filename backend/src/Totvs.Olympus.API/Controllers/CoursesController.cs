using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.RepositoryContracts;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseRepository courseService)
    {
      _courseRepository = courseService;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Route("lookup")]
    public async Task<IEnumerable<CourseDTO>> LookupCursos()
    {
      return await _courseRepository.GetLookupCourses();
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IQueryResult<CourseDTO>> GetAllCourses([FromQuery] string filter, [FromQuery] RequestAllOptionsDTO optionsDTO)
    {
      var result = await _courseRepository.GetAllPaginatedCourses(filter, optionsDTO);
      return result;
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<Course> InputCourse([FromBody] CourseInputDTO course)
    {
      var result = await _courseRepository.CreateCourse(course);
      return result;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<DetailCourseDTO> GetDetailCourse(Guid id)
    {
      var result = await _courseRepository.GetCourseById(id);
      return result;
    }
  }
}
