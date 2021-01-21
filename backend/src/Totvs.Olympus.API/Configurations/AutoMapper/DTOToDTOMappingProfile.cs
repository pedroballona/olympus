using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;

namespace Totvs.Olympus.API.Configurations.AutoMapper
{

  /// <summary>
  /// 
  /// </summary>
  [ExcludeFromCodeCoverage]
  public class DTOToDTOMappingProfile : Profile
  {
    /// <summary>
    /// 
    /// </summary>
    public DTOToDTOMappingProfile()
    {
      CreateMap<BasicCourseDataDTO, CourseDTO>().
        ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Nome)).
        ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Slug));
    }
  }
}
