using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.API.Configurations.AutoMapper
{
  /// <summary>
  /// Domain to DTO mapping.
  /// Use when the names of properties are different.
  /// </summary>
  [ExcludeFromCodeCoverage]
  public class DomainModelToDTOMappingProfile : Profile
  {
    /// <summary>
    /// Standard constructor.
    /// </summary>
    public DomainModelToDTOMappingProfile()
    {
      MapEntities();
      MappingValueObjects();
    }

    private void MapEntities()
    {
      CreateMap<Course, CourseDTO>();
      CreateMap<LearningPath, LearningPathDTO>();
    }
    private void MappingValueObjects()
    {

    }
  }
}
