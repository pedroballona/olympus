using System;
using System.Collections.Generic;

namespace Totvs.Olympus.Domain.ValueObjects
{
  public class Instructor
  {
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IList<string> Expertise { get; private set; }

    public Instructor(string name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }

    public IEnumerable<string> AddNewExpertise(string expertise)
    {
      this.Expertise.Add(expertise);
      return this.Expertise;
    }
  }
}
