using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.Interfaces;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Infrastructure.Models;

namespace Totvs.Olympus.Infrastructure.Services
{
  public class CourseRepository : ICourseRepository
  {
    private readonly IMongoCollection<Course> _collection;
    private readonly IMapper _mapper;
    private readonly INotificationContext _notificationContext;

    public CourseRepository(IOlympusDatabaseSettings settings,
                              IMapper mapper, 
                              INotificationContext notificationContext)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _collection = database.GetCollection<Course>(nameof(Course));
      _mapper = mapper;
      _notificationContext = notificationContext;
    }

    public async Task<Course> CreateCourse(CourseInputDTO course)
    {
      var mappedCourse = new Course(course);
      await _collection.InsertOneAsync(mappedCourse);
      return mappedCourse;
    }

    public async Task<IQueryResult<CourseDTO>> GetAllPaginatedCourses(string filter, RequestAllOptionsDTO optionsDTO)
    {
      var result = _collection.AsQueryable().
                               Select(x => new CourseDTO()
                               {
                                 Id = x.Id,
                                 Title = x.Title
                               });

      if (!string.IsNullOrEmpty(filter))
        result = result.Where(x => x.Title.ToLower().Contains(filter.ToLower()));
      
      var paginated = await result.Paginate(optionsDTO);

      if (paginated.Items.Any())
        return paginated;

      _notificationContext.AddNotification("NO_COURSE_FOUND.", "No course was found with this filters.", EStatusCodeNotification.NotFound);
      return null;
    }

    public async Task<Course> GetCourseByExternalId(string externalId)
    {
      var result = await _collection.FindAsync(x => x.ExternalId == externalId);
      return await result.FirstOrDefaultAsync();
    }

    public async Task<DetailCourseDTO> GetCourseById(Guid id)
    {
      var ret = await _collection.FindAsync(x => x.Id == id);
      var result =  await ret.FirstOrDefaultAsync();

      if (result is null)
      {
        _notificationContext.AddNotification("NO_COURSE_FOUND.", "No course was found with this Id.", EStatusCodeNotification.NotFound);
        return default(DetailCourseDTO);
      }

      return new DetailCourseDTO()
      {
        Title = result.Title,
        Description = result.Title,
        FirstClass = result.FirstClass,
        Instructors = result.Instructors.Select(x => x.Name),
        Score = result.Score
      };
    }
  }
}
