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
               .NotNull().MaximumLength(100); 

            RuleFor(x => x.UnitName)
              .NotEmpty()
              .NotNull()
              .MaximumLength(150);

            RuleFor(x => x.Status)
             .NotEmpty()
             .NotNull();

        }
    }
}
