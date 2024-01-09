using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Tankkaarten.CreateTankkaart
{
    public class CreateTankkaartCommandValidator : AbstractValidator<CreateTankkaartCommand>
    {
        private readonly IReadDbContext _readContext;
        public CreateTankkaartCommandValidator(IReadDbContext readContext)
        {
            _readContext = readContext;


            When(x => !string.IsNullOrWhiteSpace(x.KaartNummer), () =>
            {
                RuleFor(x => x.KaartNummer)
                    .MaximumLength(50).WithMessage("{PropertyName} mag niet meer dan 50 tekens bevatten.")
                    .MustAsync(IsKaarttnummerUnique).WithMessage("{PropertyName} is al in gebruik.");

            }).Otherwise(() => 
            {
                RuleFor(x => x.KaartNummer)
                    .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                    .NotNull();

            });


            RuleFor(x => x.GeldigheidsDatum)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .Must(x => x > DateTime.Now).WithMessage("{PropertyName} mag niet in het verleden liggen.").When(x => x.GeldigheidsDatum != default);


            RuleFor(x => x.Pincode)
                .MaximumLength(50).WithMessage("{PropertyName} mag niet meer dan 50 tekens bevatten.");
            
        }

        private async Task<bool> IsKaarttnummerUnique(string nummer, CancellationToken ct)
        {
            return !await _readContext.Query<Tankkaart>().AnyAsync(x => x.KaartNummer == nummer, ct);
        }
    }
}
