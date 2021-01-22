using Microsoft.Extensions.DependencyInjection;
using Totvs.Olympus.Domain.Entities.Base;
using Totvs.Olympus.Domain.Interfaces;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Infrastructure.Repositories;

namespace Totvs.Olympus.API.Infrastructure
{
  public static class RepositoriesDI
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<INotificationContext, NotificationContext>();
      services.AddScoped<ICoursesRepository, CoursesRepository>();
      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }
  }
}
