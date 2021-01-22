using System;
using System.Collections.Generic;
using System.Text;

namespace Totvs.Olympus.CrossCutting.DTOs
{
  public class DetailCourseDTO
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Instructors { get; set; }
    public double Score { get; set; }
    public Uri FirstClass { get; set; }
  }
}
