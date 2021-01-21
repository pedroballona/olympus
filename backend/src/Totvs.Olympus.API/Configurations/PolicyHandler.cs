using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Totvs.Olympus.API.Configurations
{
  public static class PolicyHandler
  {
    /// <summary>
    /// Get retry policy
    /// </summary>
    /// <param name="retryCount"></param>
    /// <returns></returns>
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount = 5)
    {
      return HttpPolicyExtensions.HandleTransientHttpError().
                                  OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound).
                                  WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    /// <summary>
    /// Timeout
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public static IAsyncPolicy<HttpResponseMessage> Timeout(int seconds = 30) =>
      Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(seconds));
  }
}
