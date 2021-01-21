using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Totvs.Olympus.API.Configurations.AutoMapper
{
  /// <summary>
  /// Configuration of auto mapper.
  /// </summary>
  [ExcludeFromCodeCoverage]
  public static class AutoMapperConfig
  {
    /// <summary>
    /// Register our mappings.
    /// </summary>
    /// <returns></returns>
    public static MapperConfiguration RegisterMappings()
    {
      return new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new DomainModelToDTOMappingProfile());
        cfg.AddProfile(new DTOToDTOMappingProfile());
      });
    }
  }
}
