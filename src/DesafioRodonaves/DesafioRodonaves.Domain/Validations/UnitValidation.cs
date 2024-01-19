using DesafioRodonaves.Domain.Commons;
using DesafioRodonaves.Domain.Entities;
using FluentValidation;

namespace DesafioRodonaves.Domain.Validations

{
    public class UnitValidation : AbstractValidator<Unit>
    {
        public UnitValidation()
        {
            RuleFor(x => x.UnitCode)
               .Must(value => !UtilsValidations.ContainsWhitespace(value)).WithMessage("O campo código da unidade não pode conter espaço em branco.")
               .NotEmpty()
               .NotNull().MaximumLength(100);

            RuleFor(x => x.UnitName)
              .Must(value => !UtilsValidations.ContainsWhitespace(value)).WithMessage("O campo nome da unidade não pode conter espaço em branco.")
              .NotEmpty()
              .NotNull()
              .MaximumLength(150);

            RuleFor(x => x.Status)
             .NotEmpty()
             .NotNull();
        }
    }
}