using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;

namespace Totvs.Olympus.Domain.ExternalServices
{
  public interface IGetDetailCoursesService
  {
    Task<DetailCourseDataDto> GetDetailCourseData(string courseId);
  }
}
