using System;
using System.Collections.Generic;

namespace Totvs.Olympus.Domain.ValueObjects
{
  public class Instructor
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<string> Expertise { get; set; }

    public Instructor(string name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }

    public Instructor(string name, IList<string> expertise)
    {
      Id = Guid.NewGuid();
      Name = name;
      Expertise = expertise;
    }

    public IEnumerable<string> AddNewExpertise(string expertise)
    {
      this.Expertise.Add(expertise);
      return this.Expertise;
    }
  }
}
