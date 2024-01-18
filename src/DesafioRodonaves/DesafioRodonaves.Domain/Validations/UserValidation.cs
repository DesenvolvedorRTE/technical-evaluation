using DesafioRodonaves.Domain.Commons;
using DesafioRodonaves.Domain.Entities;
using FluentValidation;

namespace DesafioRodonaves.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Login)
               .Must(value => !UtilsValidations.ContainsWhitespace(value)).WithMessage("O campo login não pode conter espaço em branco.")
              .NotEmpty()
              .NotNull()
              .MaximumLength(100);

            RuleFor(x => x.Password)
              .Must(value => !UtilsValidations.ContainsWhitespace(value)).WithMessage("O campo senha não pode conter espaço em branco.")
              .NotEmpty()
              .NotNull()
              .MaximumLength(150)
              .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$!%^&*])[A-Za-z\d@#$!%^&*]{8,}$")
              .WithMessage("A senha deve conter no mínimo 1 letra maiúscula, 1 letra minúsculas, 1 caracter especial e 8 caracteres.");

            RuleFor(x => x.Status)
              .NotEmpty()
              .NotNull();
        }
    }
}
