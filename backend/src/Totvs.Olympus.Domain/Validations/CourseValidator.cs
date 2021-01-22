using FluentValidation;
using Totvs.Olympus.Domain.Entities;
using static Totvs.Olympus.Domain.Validations.ValidationHelper;

namespace Totvs.Olympus.Domain.Validations
{
  public class CourseValidator : AbstractValidator<Course>
  {
    public CourseValidator()
    {
      RuleFor(c => c.Title).
         NotEmpty().
         WithMessage("Course title can't be empty.");

      RuleFor(c => c.Score).
        NotEmpty().
        NotNull().
        Must(NotBeNegative).
        WithMessage("Score can't be negative.");
    }
  }
}
