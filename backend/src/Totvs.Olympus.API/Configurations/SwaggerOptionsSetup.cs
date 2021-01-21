using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Totvs.Olympus.API.Configurations
{
  [ExcludeFromCodeCoverage]
  public static class SwaggerOptionsSetup
  {
    public static IServiceCollection AddAutoSwaggerSetup(this IServiceCollection services, IConfiguration configuration)
    {
      return services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Totvs Olympus API", Version = "v1" });
        //options.SwaggerDoc("v2", new OpenApiInfo { Title = "Totvs Olympus API", Version = "v2" });

        options.CustomSchemaIds(type => type.ToString());

        //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Totvs.Olympus.API.xml"));        
      });
    }
  }
}
