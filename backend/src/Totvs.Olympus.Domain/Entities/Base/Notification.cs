using System;
using System.Collections.Generic;
using System.Text;

namespace Totvs.Olympus.Domain.Entities
{
  public class Notification
  {
    public string Key { get; }
    public string Message { get; }
    public EStatusCodeNotification StatusCode { get; set; }

    public Notification(string key, string message) : this(key, message, EStatusCodeNotification.BadRequest)
    {

    }

    public Notification(string key, string message, EStatusCodeNotification statusCodeNotification)
    {
      Key = key;
      Message = message;
      StatusCode = statusCodeNotification;
    }
  }
}
