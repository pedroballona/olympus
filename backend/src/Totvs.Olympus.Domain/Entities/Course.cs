﻿using System;
using System.Collections.Generic;
using System.Linq;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.ValueObjects;

namespace Totvs.Olympus.Domain.Entities
{
  public class Course
  {
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public double Score { get; private set; }
    public IEnumerable<Instructor> Instructors { get; private set; }
    public Uri LinkExternalCourse { get; private set; }

    public Course(string name,
                  double note,
                  IEnumerable<Instructor> instructors, 
                  Uri linkExternalCourse = null)
    {
      Id = Guid.NewGuid();
      Name = name;
      Score = note;
      Instructors = instructors;
      LinkExternalCourse = linkExternalCourse;
    }

    public Course(CourseInputDTO course)
    {
      Id = Guid.NewGuid();
      Name = course.Name;
      Score = course.Score;
      Instructors = course.Instructors.Select(x => new Instructor(x.Name, x.Expertise.ToList()));
      LinkExternalCourse = course.LinkExternalCourse;
    }
  }
}
