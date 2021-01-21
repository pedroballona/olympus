using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Totvs.Olympus.API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Title = "Totvs Olympus API";
      CreateWebHostBuilder(args).
      ConfigureAppConfiguration((hostingContext, config) =>
      {
        var env = hostingContext.HostingEnvironment;

        config
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: false)
            .AddEnvironmentVariables();
      }).
      ConfigureLogging((hostingContext, logging) =>
      {
        var loggerConfiguration = new LoggerConfiguration()
                  .Enrich.WithMachineName()
                  .ReadFrom.Configuration(hostingContext.Configuration);

        Log.Logger = loggerConfiguration.CreateLogger();
      })
              .UseStartup<Startup>()
              .UseSerilog()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseSetting("detailedErrors", "true")
              .Build()
              .Run();
    }


    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
  }
}
