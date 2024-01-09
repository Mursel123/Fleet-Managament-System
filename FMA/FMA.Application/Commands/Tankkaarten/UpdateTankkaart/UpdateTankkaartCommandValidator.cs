using FluentValidation;

namespace FMA.Application.Commands.Tankkaarten.UpdateTankkaart
{
    public class UpdateTankkaartCommandValidator : AbstractValidator<UpdateTankkaartCommand>
    {
        public UpdateTankkaartCommandValidator()
        {

            RuleFor(x => x.GeldigheidsDatum)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull();

            RuleFor(x => x.Pincode)
                .MaximumLength(50).WithMessage("{PropertyName} mag niet meer dan 50 tekens bevatten.");

        }
    }
}
