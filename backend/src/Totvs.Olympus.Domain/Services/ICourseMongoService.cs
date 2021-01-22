using System;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.Services
{
  public interface ICourseMongoService
  {
    Task<Course> CreateCourse(CourseInputDTO course);
    Task<IQueryResult<CourseDTO>> GetAllPaginatedCourses(string filter, RequestAllOptionsDTO optionsDTO);
    Task<DetailCourseDTO> GetCourseById(Guid id);
  }
}
