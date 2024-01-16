using DesafioRodonaves.Domain.Entities;
using FluentValidation;

namespace DesafioRodonaves.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Login)
              .NotEmpty()
              .NotNull()
              .MaximumLength(100);

            RuleFor(x => x.Password)
              .NotEmpty()
              .NotNull()
              .MaximumLength(150);

            RuleFor(x => x.Status)
              .NotEmpty()
              .NotNull();
        }
    }
}
