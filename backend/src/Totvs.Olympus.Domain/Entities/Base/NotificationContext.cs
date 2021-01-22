using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using Totvs.Olympus.Domain.Interfaces;

namespace Totvs.Olympus.Domain.Entities.Base
{
  public class NotificationContext : INotificationContext
	{
		private readonly List<Notification> _notifications;
		public IReadOnlyCollection<Notification> Notifications => _notifications;
		public bool HasNotifications => _notifications.Any();

		public NotificationContext()
		{
			_notifications = new List<Notification>();
		}

		public void AddNotification(string key, string message)
		{
			_notifications.Add(new Notification(key, message));
		}

		public void AddNotification(Enum key, string message)
		{
			_notifications.Add(new Notification(key.ToString(), message));
		}

		public void AddNotification(Notification notification)
		{
			_notifications.Add(notification);
		}

		public void AddNotifications(IReadOnlyCollection<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(IEnumerable<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ICollection<Notification> notifications)
		{
			_notifications.AddRange(notifications);
		}

		public void AddNotifications(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				AddNotification(error.ErrorCode, error.ErrorMessage);
			}
		}

		public void AddNotification(string key, string message, EStatusCodeNotification statusCode)
		{
			_notifications.Add(new Notification(key, message, statusCode));
		}

		public void AddNotification(Enum key, string message, EStatusCodeNotification statusCode)
		{
			_notifications.Add(new Notification(key.ToString(), message, statusCode));
		}

		public EStatusCodeNotification GetStatusCode()
		{
			if (_notifications.Any(n => n.StatusCode == EStatusCodeNotification.BadRequest))
				return EStatusCodeNotification.BadRequest;
			else if (_notifications.All(n => n.StatusCode == EStatusCodeNotification.NotFound))
				return EStatusCodeNotification.NotFound;
			else
				return EStatusCodeNotification.BadRequest;
		}
	}
}
