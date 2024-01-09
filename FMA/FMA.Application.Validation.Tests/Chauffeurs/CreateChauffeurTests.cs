using FluentValidation.TestHelper;
using FMA.Application.Commands.Chauffeurs.CreateChauffeur;
using FMA.Contracts.Persistence;
using NSubstitute;

namespace FMA.Application.Validation.Tests.Chauffeurs
{
    [TestFixture]
    public class CreateChauffeurTests
    {
        private CreateChauffeurCommandValidator _validator;
        private IReadDbContext _context;

        [SetUp]
        public void OneTimeSetup()
        {
            _context = Substitute.For<IReadDbContext>();
            _validator = new(_context);
        }

        [Test]
        public async Task Rijksregisternummer_Should_NotBeEmpty()
        {
            var chauffeur = new CreateChauffeurCommand() { Rijksregisternummer = "" };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Rijksregisternummer).WithErrorMessage("Rijksregisternummer is verplicht.");

        }

        [Test]
        public async Task Rijksregisternummer_Should_HaveInvalidFormat()
        {
            var chauffeur = new CreateChauffeurCommand() { Rijksregisternummer = "invalid_format" };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Rijksregisternummer).WithErrorMessage("Rijksregisternummer is niet geldig.");

        }

        [Test]
        public async Task Rijksregisternummer_Should_HaveCorrectLength()
        {
            var chauffeur = new CreateChauffeurCommand() { Rijksregisternummer = "12.45.78-025.234", Geboortedatum = new DateTime(2001, 1, 1) };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Rijksregisternummer).WithErrorMessage("Rijksregisternummer is niet geldig.");

        }

        [Test]
        public async Task Geboortedatum_Should_NotBeEmpty()
        {
            var chauffeur = new CreateChauffeurCommand() { Geboortedatum = default };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Geboortedatum).WithErrorMessage("Geboortedatum is verplicht.");
        }

        [Test]
        public async Task Voornaam_Should_NotBeEmpty()
        {
            var chauffeur = new CreateChauffeurCommand() { Voornaam = "" };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Voornaam).WithErrorMessage("Voornaam is verplicht.");

        }

        [Test]
        public async Task Voornaam_Should_NotBeNull()
        {
            var chauffeur = new CreateChauffeurCommand  () { Voornaam = null };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Voornaam).WithErrorMessage("Voornaam is verplicht.");

        }

        [Test]
        public async Task Voornaam_Should_HaveMaximumLength()
        {
            var chauffeur = new CreateChauffeurCommand() { Voornaam = "a".PadRight(256, 'a') };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Voornaam).WithErrorMessage("Voornaam mag niet meer dan 255 tekens bevatten.");

        }

        [Test]
        public async Task Naam_Should_NotBeEmpty()
        {
            var chauffeur = new CreateChauffeurCommand() { Naam = "" };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Naam).WithErrorMessage("Naam is verplicht.");

        }

        [Test]
        public async Task Naam_Should_HaveMaximumLength()
        {
            var chauffeur = new CreateChauffeurCommand() { Naam = "a".PadRight(256, 'a') };
            var result = await _validator.TestValidateAsync(chauffeur);
            result.ShouldHaveValidationErrorFor(x => x.Naam).WithErrorMessage("Naam mag niet meer dan 255 tekens bevatten.");

        }
    }
}