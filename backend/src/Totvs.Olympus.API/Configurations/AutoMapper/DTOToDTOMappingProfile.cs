using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

      CreateMap<DetailCourseDataDto, DetailCourseDTO>().
        ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Join(". ", src.Chamadas))).
        ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Nota)).
        ForMember(dest => dest.InstructorsNames, opt => opt.MapFrom(src => src.Instrutores.Select(s => s.Nome)));
    }
  }
}
