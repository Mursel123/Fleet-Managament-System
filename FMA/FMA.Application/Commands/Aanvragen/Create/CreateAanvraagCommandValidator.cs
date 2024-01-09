using FluentValidation;
using System;
using FMA.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Aanvragen.Create
{
    public class CreateAanvraagCommandValidator : AbstractValidator<CreateAanvraagCommand>
    {
        public CreateAanvraagCommandValidator()
        {
            RuleFor(x => x.BeginPeriode)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull();


            RuleFor(x => x.AanvraagType)
                .IsInEnum()
                .NotNull().WithMessage("{PropertyName} is verplicht.");

            RuleFor(x => x.BeginPeriode)
                .LessThan(x => x.EindPeriode)
                .WithMessage("Begin periode mag niet hoger zijn dan de eind periode ");

            When(x => x.AanvraagType == AanvraagType.Herstelling || x.AanvraagType == AanvraagType.Onderhoud, () =>
            {
                RuleFor(x => x.VoertuigId)
                .NotNull().WithMessage("{PropertyName} is verplicht.");
            });
        }
    }
}
