using System;
using System.Collections.Generic;
using System.Text;

namespace Totvs.Olympus.Domain.Entities
{
  public abstract class Entity
  {
    public Guid Id { get; private set; }
    public DateTime DateCreated { get; private set; }
    public DateTime DateUpdated { get; private set; }
    public bool Active { get; private set; }

    protected Entity()
    {
      Id = Guid.NewGuid();
      DateCreated = DateTime.Now;
      DateUpdated = DateTime.Now;
      Active = true;
    }
  }
}
