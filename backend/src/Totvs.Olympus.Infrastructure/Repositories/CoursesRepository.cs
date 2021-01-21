using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    private readonly IGetDetailCoursesService _getDetailCoursesService;
    private readonly IMapper _mapper;

    public CoursesRepository(IGetAllCoursesFromAluraService getAllService,
                             IGetDetailCoursesService getDetailCoursesService,
                             IMapper mapper)
    {
      _getAllService = getAllService;
      _getDetailCoursesService = getDetailCoursesService;
      _mapper = mapper;
    }

    public async Task<IQueryResult<CourseDTO>> GetAllPaginatedContracts(string filter, RequestAllOptionsDTO optionsDTO)
    {
      var result = await _getAllService.GetCourses();

      if (!string.IsNullOrEmpty(filter))
        result = result.Where(x => x.Nome.ToLower().Contains(filter.ToLower()));

      var mapped = _mapper.Map<IEnumerable<CourseDTO>>(result);

      return AutoMapperQueryble.Paginate(mapped, optionsDTO);
    }

    public async Task<DetailCourseDTO> GetDetailCourse(string courseId)
    {
      var result = await _getDetailCoursesService.GetDetailCourseData(courseId);

      return _mapper.Map<DetailCourseDTO>(result);
    }
  }
}
