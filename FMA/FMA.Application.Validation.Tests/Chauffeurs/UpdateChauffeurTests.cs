using FluentValidation.TestHelper;
using FMA.Application.Commands.Chauffeurs.UpdateChauffeur;

namespace FMA.Application.Validation.Tests.Chauffeurs
{
    public class UpdateChauffeurTests
    {
        private UpdateChauffeurCommandValidator _validator;

        [SetUp]
        public void OneTimeSetup()
        {
            _validator = new();

        }

        [Test]
        public async Task Voornaam_Should_NotBeEmpty()
        {
            var chauffeur = new UpdateChauffeurCommand() { Voornaam = "" };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Voornaam)
                .WithErrorMessage("Voornaam is verplicht.");
        }

        [Test]
        public async Task Voornaam_Should_NotBeNull()
        {
            var chauffeur = new UpdateChauffeurCommand() { Voornaam = null };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Voornaam)
                .WithErrorMessage("Voornaam is verplicht.");
        }

        [Test]
        public async Task Voornaam_Should_HaveMaximumLength()
        {
            var chauffeur = new UpdateChauffeurCommand() { Voornaam = "a".PadRight(256, 'a') };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Voornaam)
                .WithErrorMessage("Voornaam mag niet meer dan 255 tekens bevatten.");
        }

        [Test]
        public async Task Naam_Should_NotBeEmpty()
        {
            var chauffeur = new UpdateChauffeurCommand() { Naam = "" };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Naam)
                .WithErrorMessage("Naam is verplicht.");
        }

        [Test]
        public async Task Naam_Should_NotBeNull()
        {
            var chauffeur = new UpdateChauffeurCommand() { Naam = null };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Naam)
                .WithErrorMessage("Naam is verplicht.");
        }

        [Test]
        public async Task Naam_Should_HaveMaximumLength()
        {
            var chauffeur = new UpdateChauffeurCommand() { Naam = "a".PadRight(256, 'a') };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Naam)
                .WithErrorMessage("Naam mag niet meer dan 255 tekens bevatten.");
        }

    }
}
