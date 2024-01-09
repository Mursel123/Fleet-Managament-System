using FluentValidation;

namespace FMA.Application.Commands.Chauffeurs.UpdateChauffeur
{
    public class UpdateChauffeurCommandValidator : AbstractValidator<UpdateChauffeurCommand>
    {
        public UpdateChauffeurCommandValidator()
        {


            RuleFor(x => x.Voornaam)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} mag niet meer dan 255 tekens bevatten.");

            RuleFor(x => x.Naam)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} mag niet meer dan 255 tekens bevatten.");
        }
    }
}
