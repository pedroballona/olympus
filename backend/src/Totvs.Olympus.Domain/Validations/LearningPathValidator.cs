using FluentValidation;
using Totvs.Olympus.Domain.Entities;
using static Totvs.Olympus.Domain.Validations.ValidationHelper;

namespace Totvs.Olympus.Domain.Validations
{
  public class LearningPathValidator : AbstractValidator<LearningPath>
  {
    public LearningPathValidator()
    {
      RuleFor(l => l.Name).
         NotEmpty().
         NotNull().
         WithMessage("Name can't be null or empty..");

      RuleFor(l => l.Description).
        NotEmpty().
        NotNull().
        WithMessage("Name can't be null or empty.");

      RuleFor(l => l.Courses).
        NotEmpty().
        NotNull().
        WithMessage("Courses can't be null or empty.");

      RuleFor(l => l.EmployeeRoles).
        NotEmpty().
        NotNull().
        WithMessage("Courses can't be null or empty.");

    }
  }
}
