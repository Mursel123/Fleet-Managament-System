using FluentValidation;

namespace FMA.Application.Commands.Onderhouden.Create
{
    public class CreateOnderhoudCommandValidator : AbstractValidator<CreateOnderhoudCommand>
    {
        public CreateOnderhoudCommandValidator()
        {

            RuleFor(x => x.DatumUitvoering)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull();

            RuleFor(x => x.VoertuigId)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is verplicht.");

            RuleFor(x => x.Kostprijs)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} mag niet onder de null!");
        }
    }
}
