using FluentValidation;
using FMA.Application.Commands.Chauffeurs.CreateChauffeur;
using FMA.Contracts.Persistence;

namespace FMA.Application.Commands.Gemeentes.Create
{
    public class CreateGemeenteCommandValidator : AbstractValidator<CreateGemeenteCommand>
    {
        private readonly IReadDbContext _readContext;
        public CreateGemeenteCommandValidator(IReadDbContext readContext)
        {
            _readContext = readContext;

            RuleFor(x => x.Postcode)
                .Matches("^[0-9]{4,4}$")
                .WithMessage("{PropertyName} is niet geldig.");

            RuleFor(x => x.Stad)
                .MaximumLength(50).WithMessage("{PropertyName} mag niet meer dan 50 tekens bevatten.");

            RuleFor(x => x.ChauffeurCommand).SetValidator(new CreateChauffeurCommandValidator(_readContext));

        }
    }
}
