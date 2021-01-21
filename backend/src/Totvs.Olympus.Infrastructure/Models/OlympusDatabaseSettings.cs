using System;
using System.Collections.Generic;
using System.Text;

namespace Totvs.Olympus.Infrastructure.Models
{
  public class OlympusDatabaseSettings : IOlympusDatabaseSettings
  {
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IOlympusDatabaseSettings
  {
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}
