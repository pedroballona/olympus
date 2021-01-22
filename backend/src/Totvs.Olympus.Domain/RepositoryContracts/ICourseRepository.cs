using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.RepositoryContracts
{
  public interface ICourseRepository
  {
    Task<Course> CreateCourse(CourseInputDTO course);
    Task<IQueryResult<CourseDTO>> GetAllPaginatedCourses(string filter, RequestAllOptionsDTO optionsDTO);
    Task<DetailCourseDTO> GetCourseById(Guid id);
    Task<Course> GetCourseByExternalId(string externalId);
    Task<List<CourseDTO>> GetLookupCourses();
  }
}
