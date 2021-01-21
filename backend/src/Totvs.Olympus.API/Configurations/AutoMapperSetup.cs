using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Totvs.Olympus.API.Configurations.AutoMapper;

namespace Totvs.Olympus.API.Configurations
{
  /// <summary>
  /// Auto mapper setup class
  /// </summary>
  [ExcludeFromCodeCoverage]
  public static class AutoMapperSetup
  {
    /// <summary>
    /// Add a auto mapper.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
    {
      if (services == null) throw new ArgumentNullException(nameof(services));

      var assemblies = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .AsEnumerable()
                                //DotNetCore.CAP assembly do not support AutoMapper
                                .Where(assembly => !assembly.FullName.Contains("DotNetCore.CAP") &&
                                                   !assembly.FullName.Contains("Microsoft.Extensions.Hosting"))
                                .ToArray();

      services.AddAutoMapper(assemblies);

      AutoMapperConfig.RegisterMappings();
      return services;
    }
  }
}
