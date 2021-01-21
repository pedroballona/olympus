using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;

namespace Totvs.Olympus.Domain.RepositoryContracts
{
  public interface ICoursesRepository
  {
    Task<IQueryResult<CourseDTO>> GetAllPaginatedContracts(string filter, RequestAllOptionsDTO optionsDTO);
    Task<DetailCourseDTO> GetDetailCourse(string courseId);
  }
}
