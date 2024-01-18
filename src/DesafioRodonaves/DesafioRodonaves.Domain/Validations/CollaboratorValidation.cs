using DesafioRodonaves.Domain.Commons;
using DesafioRodonaves.Domain.Entities;
using FluentValidation;

namespace DesafioRodonaves.Domain.Validations
{
    public class CollaboratorValidation : AbstractValidator<Collaborator>
    {
        public CollaboratorValidation() 
        {
            RuleFor(x => x.Name)
               .Must(value => !UtilsValidations.ContainsWhitespace(value)).WithMessage("O campo nome não pode conter espaço em branco.")
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);

            RuleFor(x => x.UnitId)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.UserId)
               .NotEmpty()
               .NotNull();
        }
    }
}
