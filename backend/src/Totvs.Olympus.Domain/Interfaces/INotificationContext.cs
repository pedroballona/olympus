using FluentValidation.Results;
using System;
using System.Collections.Generic;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.Interfaces
{
  public interface INotificationContext
  {
    IReadOnlyCollection<Notification> Notifications { get; }
    bool HasNotifications { get; }
    void AddNotification(string key, string message);
    void AddNotification(Enum key, string message);
    void AddNotification(Notification notification);
    void AddNotifications(IReadOnlyCollection<Notification> notifications);
    void AddNotifications(IEnumerable<Notification> notifications);
    void AddNotifications(ICollection<Notification> notifications);
    void AddNotifications(ValidationResult validationResult);
    void AddNotification(string key, string message, EStatusCodeNotification statusCode);
    void AddNotification(Enum key, string message, EStatusCodeNotification statusCode);

    EStatusCodeNotification GetStatusCode();
  }
}
