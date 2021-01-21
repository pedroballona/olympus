using Microsoft.Extensions.DependencyInjection;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Infrastructure.Repositories;

namespace Totvs.Olympus.API.Infrastructure
{
  public static class RepositoriesDI
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<ICoursesRepository, CoursesRepository>();

      return services;
    }
  }
}
