using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Herstellingen.Create
{
    public class CreateHerstellingCommandValidator : AbstractValidator<CreateHerstellingCommand>
    {
        public CreateHerstellingCommandValidator()
        {
            RuleFor(x => x.DatumUitvoering)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull();

            RuleFor(x => x.AanvraagId)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull();

            RuleFor(x => x.VerzekeringsmaatschappijId)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull();

            RuleFor(x => x.VoertuigId)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is verplicht.");
        }
    }
}
