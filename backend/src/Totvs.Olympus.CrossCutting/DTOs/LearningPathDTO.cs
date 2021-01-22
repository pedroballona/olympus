using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Olympus.CrossCutting.Enums;

namespace Totvs.Olympus.CrossCutting.DTOs
{
  public class LearningPathDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Guid> Courses { get; set; }
    public IEnumerable<EEmployeeRole> EmployeeRoles { get; set; }
  }
}
