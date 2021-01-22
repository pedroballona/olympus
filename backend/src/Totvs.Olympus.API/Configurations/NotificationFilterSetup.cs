using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Totvs.Olympus.Domain.Interfaces;

namespace Totvs.Olympus.API.Configurations
{
  public class NotificationFilterSetup : IAsyncResultFilter
  {
    private readonly INotificationContext _notificationContext;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="notificationContext"></param>
    public NotificationFilterSetup(INotificationContext notificationContext)
    {
      _notificationContext = notificationContext;
    }

    /// <summary>
    /// Send BadRequest (400) code when has notifications
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
      if (_notificationContext.HasNotifications)
      {
        context.HttpContext.Response.StatusCode = (int)_notificationContext.GetStatusCode();
        context.HttpContext.Response.ContentType = "application/json";

        var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
        await context.HttpContext.Response.WriteAsync(notifications);

        return;
      }

      await next();
    }
  }
}
