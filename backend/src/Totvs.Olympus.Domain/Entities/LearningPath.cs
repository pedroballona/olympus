using System;
using System.Collections.Generic;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.CrossCutting.Enums;
using Totvs.Olympus.Domain.Validations;

namespace Totvs.Olympus.Domain.Entities
{
  public class LearningPath : Entity
  {
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<Guid> Courses { get; private set; }
    public IEnumerable<EEmployeeRole> EmployeeRoles { get; private set; }

    public LearningPath(LearningPathDTO learningPathDTO)
    {
      Name = learningPathDTO.Name;
      Description = learningPathDTO.Description;
      Courses = learningPathDTO.Courses;
      EmployeeRoles = learningPathDTO.EmployeeRoles;
      Validate();
    }

    public void Validate()
    {
      Validate(this, new LearningPathValidator());
    }
  }
}
