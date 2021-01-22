using FluentValidation;
using Totvs.Olympus.Domain.Entities;
using static Totvs.Olympus.Domain.Validations.ValidationHelper;

namespace Totvs.Olympus.Domain.Validations
{
  public class UserValidator : AbstractValidator<User>
  {
    public UserValidator()
    {
      RuleFor(u => u.Name).
        NotEmpty().
        WithMessage("O nome do usuário não pode ser vazio");

      RuleFor(u => u.Email).
        NotEmpty().
        NotNull().
        Must(BeAValidEmail).
        WithMessage("Deve ser um email válido.");
    }
  }
}
