using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Totvs.Olympus.API.Configurations;

namespace Totvs.Olympus.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvcCore(options => options.EnableEndpointRouting = true);

      services.AddControllers();
      services.AddApiVersioning();
      services.AddVersionedApiExplorer(p =>
      {
        p.GroupNameFormat = "'v'VVV";
        p.SubstituteApiVersionInUrl = true;
      });
      services.AddAutoSwaggerSetup(this.Configuration);
      services.SetupAluraService(this.Configuration);
      services.SetupMongoDatabase(this.Configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger, IApiVersionDescriptionProvider apiVersion)
    {
      app.UseSwagger();
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      string basePath = Configuration["BasePath"] ?? string.Empty;

      if (!string.IsNullOrEmpty(basePath))
      {
        logger.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", basePath);
        app.UsePathBase(basePath);
      }

      app.UseCors(builder => builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .WithExposedHeaders("Content-Disposition", "File-Name"));

      app.UseSwaggerUI(options =>
      {
        foreach (var description in apiVersion.ApiVersionDescriptions)
        {
          options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            $"TOTVS Olympus API {description.GroupName.ToUpperInvariant()}");
        }
      });

      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
