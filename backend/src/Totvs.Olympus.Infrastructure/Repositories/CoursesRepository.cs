using System;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.RepositoryContracts;

namespace Totvs.Olympus.Infrastructure.Repositories
{
  public class CoursesRepository : ICoursesRepository
  {
    public Task<IQueryResult<CourseDTO>> GetAllPaginatedContracts()
    {
      throw new NotImplementedException();
    }
  }
}
