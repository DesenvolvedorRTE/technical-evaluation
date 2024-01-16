using DesafioRodonaves.Domain.Entities;
using FluentValidation;

namespace DesafioRodonaves.Domain.Validations

{
    public class UnitValidation : AbstractValidator<Unit>
    {

        public UnitValidation()
        {
          
            RuleFor(x => x.UnitCode)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.UnitName)
              .NotEmpty()
              .NotNull()
              .MaximumLength(150);

        }
    }
}
