using System;
using System.Collections.Generic;
using Totvs.Olympus.Domain.ValueObjects;

namespace Totvs.Olympus.Domain.Entities
{
  public class Course
  {
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public double Note { get; private set; }
    public IEnumerable<Instructor> Instructors { get; private set; }
    public Uri LinkExternalCourse { get; private set; }

    public Course(string name, 
                  double note, 
                  IEnumerable<Instructor> instructors)
    {
      Id = Guid.NewGuid();
      Name = name;
      Note = note;
      Instructors = instructors;
    }
  }
}
