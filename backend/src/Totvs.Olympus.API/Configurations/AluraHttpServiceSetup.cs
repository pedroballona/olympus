using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Totvs.Olympus.CrossCutting.ExternalServices.Enum;
using Totvs.Olympus.Domain.ExternalServices;
using Totvs.Olympus.Infrastructure.ExternalServices;

namespace Totvs.Olympus.API.Configurations
{
  public static class AluraHttpServiceSetup
  {
    public static IServiceCollection SetupAluraService(this IServiceCollection services,
                                                       IConfiguration configuration)
    {
      var aluraApiHost = configuration.GetSection("ConnectionStrings:AluraApiHost").Value;

      services.AddHttpClient(nameof(EHttpClientNames.Alura), c =>
      {
        c.BaseAddress = new Uri(aluraApiHost);
      }).
               SetHandlerLifetime(TimeSpan.FromMinutes(5)).
               AddPolicyHandler(PolicyHandler.GetRetryPolicy()).
               AddPolicyHandler(PolicyHandler.Timeout());

      services.AddScoped<IAluraHttpService, AluraHttpService>();

      return services;
    }
  }
}
