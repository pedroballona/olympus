using System.Collections.Generic;

namespace Totvs.Olympus.CrossCutting.DTOs
{
  public class CourseDTO
  {
    public string Title { get; set; }
    public double Rating { get; set; }
    public string Id { get; set; }
    public IEnumerable<string> Instructors { get; set; }
  }
}
