using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DTOs;

namespace Totvs.Olympus.Domain.Services
{
  public interface ICourseService
  {
    Task<CourseDTO> CreateCourse(CourseDTO course);
  }
}
