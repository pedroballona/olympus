using System;
using System.Collections.Generic;
using System.Text;

namespace Totvs.Olympus.CrossCutting.DTOs
{
  public class InstructorDTO
  {
    public string Name { get; set; }
    public IEnumerable<string> Expertise { get; set; }
  }
}
