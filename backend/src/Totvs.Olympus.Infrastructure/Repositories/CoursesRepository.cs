using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.ExternalServices;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Infrastructure.Adapter;

namespace Totvs.Olympus.Infrastructure.Repositories
{
  public class CoursesRepository : ICoursesRepository
  {
    private readonly IGetAllCoursesFromAluraService _getAllService;
    private readonly IMapper _mapper;

    public CoursesRepository(IGetAllCoursesFromAluraService getAllService, 
                             IMapper mapper)
    {
      _getAllService = getAllService;
      _mapper = mapper;
    }

    public async Task<IQueryResult<CourseDTO>> GetAllPaginatedContracts()
    {
      var result = await _getAllService.GetCourses();

      var mapped = _mapper.Map<IEnumerable<CourseDTO>>(result);

      return AutoMapperQueryble.Paginate(mapped, new PaginationOptions<CourseDTO>());
    }
  }
}
