using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;

namespace Totvs.Olympus.Domain.ExternalServices
{
  public interface IGetAllCoursesFromAluraService
  {
    Task<IEnumerable<BasicCourseDataDTO>> GetCourses();
  }
}
