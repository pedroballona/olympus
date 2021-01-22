using System;
using System.Collections.Generic;
using System.Text;

namespace Totvs.Olympus.CrossCutting.DTOs
{
  public class CourseInputDTO
  {
    public string Title { get; set; }
    public double Score { get; set; }
    public IEnumerable<InstructorDTO> Instructors { get; set; }
    public Uri LinkExternalCourse { get; set; }
    public Uri FirstClass { get; set; }
    public string ExternalId { get; set; }
  }
}
