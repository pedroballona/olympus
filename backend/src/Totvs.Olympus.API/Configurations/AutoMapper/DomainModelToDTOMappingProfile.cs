using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
      CreateMap<Course, CourseDTO>().
        ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
        ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
        ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
      CreateMap<Course, DetailCourseDTO>().
        ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)).
        ForMember(dest => dest.Description, opt => opt.Ignore()).
        ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors.Select(i => i.Name).ToArray())).
        ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));
      CreateMap<LearningPath, LearningPathDTO>();
      CreateMap<User, UserDTO>();
    }
    private void MappingValueObjects()
    {

    }
  }
}
