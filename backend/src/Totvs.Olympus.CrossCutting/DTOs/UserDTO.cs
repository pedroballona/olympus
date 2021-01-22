using System;
using System.Collections.Generic;

namespace Totvs.Olympus.CrossCutting.DTOs
{
  public class UserDTO
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Uri Image { get; set; }
    public IEnumerable<Guid> Courses { get; set; }
    public IEnumerable<Guid> LearningPaths { get; set; }
  }
}
