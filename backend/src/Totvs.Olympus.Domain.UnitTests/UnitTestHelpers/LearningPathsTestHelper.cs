using System;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.CrossCutting.Enums;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.UnitTests.UnitTestHelpers
{
  public static class LearningPathsTestHelper
  {
    public static LearningPathDTO GetValidLearningPathDTO()
    {
      return new LearningPathDTO()
      {
        Name = "Caminho das pedras",
        Description = "Aquele lá",
        Courses = new[] { Guid.NewGuid() },
        EmployeeRoles = new[] { EEmployeeRole.AnalystI }
      };
    }

    public static LearningPathDTO GetInvalidLearningPathDTO()
    {
      return new LearningPathDTO()
      {
        Name = string.Empty,
        Description = string.Empty,
        Courses = null,
        EmployeeRoles = null
      };
    }

    public static LearningPath GetValidLearningPath()
    {
      return new LearningPath(GetValidLearningPathDTO());
    }

    public static LearningPath GetInvalidLearningPath()
    {
      return new LearningPath(GetInvalidLearningPathDTO());
    }
  }
}
