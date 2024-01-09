using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FMA.Application.Commands.Chauffeurs.CreateChauffeur
{
    public class CreateChauffeurCommandValidator : AbstractValidator<CreateChauffeurCommand>
    {
        private readonly IReadDbContext _readContext;
        public CreateChauffeurCommandValidator(IReadDbContext readContext)
        {
            _readContext = readContext;


            RuleFor(x => x.Geboortedatum)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .Must(Is18YearsOld).WithMessage("{PropertyName} is jonger dan 18 jaar.");

            RuleFor(x => x.Geslacht)
                .IsInEnum()
                .NotNull().WithMessage("{PropertyName} is verplicht.");


            When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
            {
                RuleFor(x => x.Email)
                .MaximumLength(255).WithMessage("{PropertyName} mag niet meer dan 255 tekens bevatten.")
                    .Must(ContainAtAndDot).WithMessage("{PropertyName} moet @ en . tekens bevatten.")
                    .MustAsync(IsEmailUnique).WithMessage("{PropertyName} is al in gebruik.");

            }).Otherwise(() =>
            {
                RuleFor(x => x.Email)
               .NotEmpty().WithMessage("{PropertyName} is verplicht.")
               .NotNull();

            });

            When(x => !string.IsNullOrWhiteSpace(x.Rijksregisternummer) && x.Rijksregisternummer.Length == 15, () =>
            {
                RuleFor(x => x.Rijksregisternummer)
                .Matches("^\\d{2}\\.\\d{2}\\.\\d{2}-\\d{3}\\.\\d{2}$")
                    .WithMessage("{PropertyName} is niet geldig.") //Voorbeeld formaat: 03.04.06-198.67
                .DependentRules(() =>
                {
                    RuleFor(x => x.Rijksregisternummer)
                    .Must((model, propertyValue) => IsRijksregisternummerValid(propertyValue, model.Geboortedatum, model.Geslacht)).WithMessage("{PropertyName} is niet geldig.")
                    .MustAsync(IsRijksregisternummerUnique).WithMessage("{PropertyName} is al in gebruik.");

                });

            }).Otherwise(() =>
            {
                RuleFor(x => x.Rijksregisternummer)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .Length(15).WithMessage("{PropertyName} is niet geldig.");

            });
       

            RuleFor(x => x.Voornaam)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} mag niet meer dan 255 tekens bevatten.");

            RuleFor(x => x.Naam)
                .NotEmpty().WithMessage("{PropertyName} is verplicht.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} mag niet meer dan 255 tekens bevatten.");
            
        }
        private async Task<bool> IsRijksregisternummerUnique(string rrn, CancellationToken ct)
        {
            return !await _readContext.Query<Chauffeur>().AnyAsync(x => x.Rijksregisternummer == rrn, ct);
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken ct)
        {
            return !await _readContext.Query<Chauffeur>().AnyAsync(x => x.Email == email, ct);
        }

        private bool Is18YearsOld(DateTime geboortedatum)
        {
            if (DateTime.Now.Year - geboortedatum.Year >= 18)
                return true;
            return false;
        }
        private bool ContainAtAndDot(string email)
        {
            return email is not null && email.Contains("@") && email.Contains(".");
        }

        private bool RijksregisternummerMatchesGeboortedatumAndGeslacht(string rrn, DateTime geboortedatum, Geslacht geslacht)
        {
           
            string[] rrnSplit = rrn.Split('.', '-');

            string yearPart = geboortedatum.Year.ToString().Substring(2);
            string monthPart = geboortedatum.Month.ToString("00");
            string dayPart = geboortedatum.Day.ToString("00");


            if (rrnSplit[0] == yearPart &&
                rrnSplit[1] == monthPart &&
                rrnSplit[2] == dayPart)
            {
                if (geslacht == Geslacht.Man && int.Parse(rrnSplit[3]) % 2 == 1)
                {
                    return true;
                }
                else if (geslacht == Geslacht.Vrouw && int.Parse(rrnSplit[3]) % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Check the checksum for a Rijksregister
        /// Link: https://sandervandevelde.wordpress.com/2020/08/13/belgische-rijksregisternummer-checksum-testen-dutch/
        /// </summary>
        /// <param name="rrn">Rijksregister number</param>
        /// <returns>True means a correct RRN checksum</returns>
        private bool IsRijksregisternummerValid(string rrn, DateTime geboortedatum, Geslacht geslacht)
        {
            bool result = RijksregisternummerMatchesGeboortedatumAndGeslacht(rrn, geboortedatum, geslacht);
            if (!result)
            {
                return false;
            }

            rrn = Regex.Replace(rrn, @"[^\d]", string.Empty);
            var rrnChecksum = Convert.ToInt32(rrn.Substring(9, 2));

            // we pick the RRN part we want to recalculate the checksum for
            var partToCalculate = rrn.Substring(0, 9);
            var rrnInt = Int64.Parse(partToCalculate);

            // we calculate the expected checksum
            var checksum = 97 - (rrnInt % 97);

            // we compare the excisting checksum with the calculated
            if (rrnChecksum == checksum)
            {
                // we have a good checksum
                return true;
            }

            //// Checksum not yet ok. We check for a possible 1900/2000 situation;

            // we repeat the same test but now with the extra '2' added to the part
            partToCalculate = "2" + partToCalculate;
            rrnInt = Int64.Parse(partToCalculate);

            // we calculate the expected checksum. again
            checksum = 97 - (rrnInt % 97);

            // we compare the excisting checksum with the calculated, again
            if (rrnChecksum == checksum)
            {
                // we have a good checksum. Person born between 2000 and now
                return true;
            }
            else
            {
                // invalid number, even after 2000 check
                return false;
            }
        }



    } 
}
