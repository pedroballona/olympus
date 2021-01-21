using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MongoDB.Driver;
using Totvs.Olympus.Infrastructure.Models;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Services;
using System.Threading.Tasks;

namespace Totvs.Olympus.Infrastructure.Services
{
  public class CourseService : ICourseService
  {
    private readonly IMongoCollection<CourseDTO> _courses;

    public CourseService(IOlympusDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _courses = database.GetCollection<CourseDTO>("courses");
    }

    public async Task<CourseDTO> CreateCourse(CourseDTO course)
    {
      await _courses.InsertOneAsync(course);
      return course;
    }
  }
}
