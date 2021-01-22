using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.Interfaces;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Domain.Services;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseMongoService _courseService;
    private readonly INotificationContext _notificationContext;

    public CoursesController(ICourseMongoService courseService, 
                             INotificationContext notificationContext)
    {
      _courseService = courseService;
      _notificationContext = notificationContext;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<IQueryResult<CourseDTO>> GetAllCourses([FromQuery] string filter, [FromQuery] RequestAllOptionsDTO optionsDTO)
    {
      var result = await _courseService.GetAllPaginatedCourses(filter, optionsDTO);

      if(result.Items.Any())
        return result;

      _notificationContext.AddNotification("NO_COURSE_FOUND.", "No course was found with this filters.", EStatusCodeNotification.NotFound);
      return null;
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
    public async Task<DetailCourseDTO> GetDetailCourse(Guid id)
    {
      var result = await _courseService.GetCourseById(id);

      if(result is null)
        _notificationContext.AddNotification("NO_COURSE_FOUND.", "No course was found with this Id.", EStatusCodeNotification.NotFound);

      return result;
    }
  }
}
