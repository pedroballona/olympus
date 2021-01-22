using FluentValidation;
using FluentValidation.Results;
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

    #region Validation properties

    [IgnoreSerialization]
    public bool Valid { get; private set; }

    [IgnoreSerialization]
    public bool Invalid => !Valid;

    [IgnoreSerialization]
    public ValidationResult ValidationResult { get; private set; }

    #endregion

    protected Entity(Guid id)
    {
      Id = id;
    }

    protected Entity()
    {
      Id = Guid.NewGuid();
      DateCreated = DateTime.Now;
      DateUpdated = DateTime.Now;
      Active = true;
    }


    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
      ValidationResult = validator.Validate(model);
      return Valid = ValidationResult.IsValid;
    }

    #region Compare methods

    public override bool Equals(object obj)
    {
      var compareTo = obj as Entity;

      if (ReferenceEquals(this, compareTo))
        return true;

      if (ReferenceEquals(null, compareTo))
        return false;

      return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity a, Entity b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;

      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;

      return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
      return !(a == b);
    }

    public override int GetHashCode()
    {
      return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
      return GetType().Name + " [Id=" + Id + "]";
    }

    #endregion
  }
}
