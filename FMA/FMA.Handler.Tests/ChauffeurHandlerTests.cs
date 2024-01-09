using FMA.Application.Commands.Chauffeurs.ActiveChauffeur;
using FMA.Application.Commands.Chauffeurs.CreateChauffeur;
using FMA.Application.Commands.Chauffeurs.UpdateChauffeur;
using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.Exceptions;
using FMA.Application.Queries.Chauffeurs.ReadChauffeurDetail;
using FMA.Application.Queries.Chauffeurs.ReadChauffeurList;
using FMA.Domain.Enums;

namespace FMA.Handler.Tests
{
    public class ChauffeurHandlerTests : IClassFixture<TestFixture>
    {
        private readonly CreateChauffeurCommandValidator _createValidator;
        private readonly UpdateChauffeurCommandValidator _updateValidator;
        private readonly CreateChauffeurCommandHandler _createHandler;
        private readonly UpdateChauffeurCommandHandler _updateHandler;
        private readonly ReadChauffeurDetailQueryHandler _readHandler;
        private readonly ReadChauffeurListQueryHandler _readListHandler;
        private readonly ActiveChauffeurCommandHandler _activeHandler;
        public ChauffeurHandlerTests(TestFixture fixture)
        {

            var context = fixture._context;
            var mapper = fixture._mapper;
            var hubcontext = fixture._hubContext;
            var options = fixture._optionsSignalR;
            fixture.CreateSamples();

            _createValidator = new(context);
            _updateValidator = new();

            _createHandler = new(context, mapper, _createValidator, hubcontext, options);
            _updateHandler = new(context, mapper, _updateValidator);
            _readHandler = new(context, mapper);
            _readListHandler = new(mapper, context);
            _activeHandler = new(context, mapper);


        }

        [Fact]
        public async Task CreateChauffeurCommandHandler_Should_Throw_ValidationException_On_IsRijksregisternummerUnique()
        {
            // Given
            var command = new CreateChauffeurCommand
            {
                Naam = "Koseer",
                Voornaam = "Mursel",
                Email = "mursel@test.com",
                Geslacht = Geslacht.Man,
                Geboortedatum = new DateTime(2001, 3, 1),
                Rijksregisternummer = "02.03.01-001.40",
            };

            // When
            var action = () => _createHandler.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<ValidationException>(action);

            // Then
            Assert.Contains("Rijksregisternummer is al in gebruik.", exception.ReadErrors());
        }


        [Theory]
        [InlineData("01.03.01-001.40", Geslacht.Vrouw)] // Vrouw moet oneven zijn
        [InlineData("02.03.01-002.40", Geslacht.Man)]   // Geboortejaar moet matchen met 1ste 2 cijfers
        [InlineData("01.03.01001.40", Geslacht.Man)]    // Middelstreep mist hier
        [InlineData("01.03.01-001.40A", Geslacht.Man)]  // Mag geen letters bevatten
        [InlineData("01.03.01.001.40", Geslacht.Man)]   // Een punt inplaats van een middelstreep
        public async Task CreateChauffeurCommandHandler_Should_Throw_ValidationException_On_IsRijksregisternummer(string rrn, Geslacht geslacht)
        {
            // Given
            var command = new CreateChauffeurCommand
            {
                Naam = "Koseer",
                Voornaam = "Mursel",
                Email = "mursel@test.com",
                Geslacht = geslacht,
                Geboortedatum = new DateTime(2001, 3, 1),
                Rijksregisternummer = rrn,
            };

            // When
            var action = () => _createHandler.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<ValidationException>(action);

            // Then
            Assert.Contains("Rijksregisternummer is niet geldig.", exception.ReadErrors());
        }

        [Fact]
        public async Task CreateChauffeurCommandHandler_Should_Throw_ValidationException_On_IsEmailUnique()
        {
            // Given
            var command = new CreateChauffeurCommand
            {
                Naam = "Koseer",
                Voornaam = "Mursel",
                Email = "mursel.koseer@test.com",
                Geslacht = Domain.Enums.Geslacht.Man,
                Geboortedatum = new DateTime(2002, 4, 2),
                Rijksregisternummer = "02.04.02-001.38",
            };

            // When
            var action = () => _createHandler.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<ValidationException>(action);

            // Then
            Assert.Contains("Email is al in gebruik.", exception.ReadErrors());
        }

        [Fact]
        public async Task CreateChauffeurCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new CreateChauffeurCommand
            {
                Naam = "Koseer",
                Voornaam = "Mursel",
                Email = "mursel@hotmail.com",
                Geslacht = Domain.Enums.Geslacht.Man,
                Geboortedatum = new DateTime(1989, 6, 5),
                Rijksregisternummer = "89.06.05-001.14",
            };

            // When
            var value = await _createHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Guid>(value);
            Assert.True(value != Guid.Empty);
        }

        [Fact]
        public async Task ReadChauffeurDetailQueryHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var query = new ReadChauffeurDetailQuery { Id = Guid.NewGuid() };

            // When
            var action = () => _readHandler.Handle(query, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task ReadChauffeurDetailQueryHandler_Should_Return_ChauffeurDTO_When_Success()
        {
            // Given
            var query = new ReadChauffeurDetailQuery { Id = Guid.Parse("3814E788-42BF-410F-84A1-A351F61BDB5F") };

            // When
            var chauffeur = await _readHandler.Handle(query, CancellationToken.None);

            // Then
            Assert.IsType<ChauffeurDTO>(chauffeur);
        }

        [Fact]
        public async Task ReadChauffeurListQueryHandler_Should_Return_ChauffeurListDTO()
        {
            // Given en When
            var chauffeurList = await _readListHandler.Handle(new ReadChauffeurListQuery(), CancellationToken.None);

            // Then
            Assert.IsType<List<ChauffeurListDTO>>(chauffeurList);
        }

        [Fact]
        public async Task UpdateChauffeurCommandHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var command = new UpdateChauffeurCommand { Id = Guid.NewGuid(), Voornaam = "Mehmet", Naam = "Van der vel" };

            // When
            var action = () => _updateHandler.Handle(command, default);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task UpdateChauffeurCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new UpdateChauffeurCommand { Id = Guid.Parse("3814E788-42BF-410F-84A1-A351F61BDB5F"), Voornaam = "Mehmet", Naam = "Van der vel" };

            // When
            var result = await _updateHandler.Handle(command, default);

            // Then
            Assert.IsType<Guid>(result);
            Assert.True(result != Guid.Empty);
        }

        [Fact]
        public async Task ActiveChauffeurCommandHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var command = new ActiveChauffeurCommand { Id = Guid.NewGuid(), IsActive = false };

            // When
            var action = () => _activeHandler.Handle(command, default);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ActiveChauffeurCommandHandler_Should_Return_Id_When_IsActive_Is_Changed(bool active)
        {
            // Given
            var command = new ActiveChauffeurCommand { Id = Guid.Parse("3814E788-42BF-410F-84A1-A351F61BDB5F"), IsActive = active };

            // When
            var result = await _activeHandler.Handle(command, default);

            // Then
            Assert.IsType<Guid>(result);
            Assert.True(result != Guid.Empty);
        }
    }
}
