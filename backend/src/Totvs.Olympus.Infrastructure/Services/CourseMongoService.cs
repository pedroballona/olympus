using AutoMapper;
using MongoDB.Driver;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.Services;
using Totvs.Olympus.Infrastructure.Models;

namespace Totvs.Olympus.Infrastructure.Services
{
  public class CourseMongoService : ICourseMongoService
  {
    private readonly IMongoCollection<Course> _courses;
    private readonly IMapper _mapper;

    public CourseMongoService(IOlympusDatabaseSettings settings, 
                              IMapper mapper)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _courses = database.GetCollection<Course>(nameof(Course));
      _mapper = mapper;
    }

    public async Task<Course> CreateCourse(CourseInputDTO course)
    {
      var mappedCourse = new Course(course);
      await _courses.InsertOneAsync(mappedCourse);
      return mappedCourse;
    }
  }
}
