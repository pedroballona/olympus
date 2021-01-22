using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Infrastructure.Models;
using Totvs.Olympus.Infrastructure.Repositories;
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

      services.AddScoped<ICourseRepository, CourseRepository>();
      services.AddScoped<ILearningPathRepository, LearningPathRepository>();
      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }
  }
}
