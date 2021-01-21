using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Totvs.Olympus.CrossCutting.ExternalServices.Enum;
using Totvs.Olympus.Domain.ExternalServices;
using Totvs.Olympus.Domain.Services;
using Totvs.Olympus.Infrastructure.ExternalServices;
using Totvs.Olympus.Infrastructure.Models;
using Totvs.Olympus.Infrastructure.Services;

namespace Totvs.Olympus.API.Configurations
{
  public static class MongoDatabaseSetup
  {
    public static IServiceCollection SetupMongoDatabase(this IServiceCollection services,
                                                        IConfiguration configuration)
    {
      services.Configure<OlympusDatabaseSettings>(configuration.GetSection("ConnectionStrings:MongoDB"));
      services.AddSingleton<IOlympusDatabaseSettings>(sp => sp.GetRequiredService<IOptions<OlympusDatabaseSettings>>().Value);

      services.AddScoped<ICourseMongoService, CourseMongoService>();

      return services;
    }
  }
}
