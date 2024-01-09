using FMA.Application.Commands.Gemeentes.Create;

namespace FMA.Handler.Tests
{
    public class GemeenteHandlerTests : IClassFixture<TestFixture>
    {
        private readonly CreateGemeenteCommandHandler _createHandler;
        private readonly CreateGemeenteCommandValidator _createValidator;
        public GemeenteHandlerTests(TestFixture fixture)
        {
            var context = fixture._context;

            fixture.CreateSamples();

            _createValidator = new(context);
            _createHandler = new(context, _createValidator);
        }

        [Fact]
        public async Task CreateGemeenteCommandHandler_Should_Return_Null()
        {
            // Given
            var command = new CreateGemeenteCommand
            {
                Postcode = "",
                Stad = "  "
            };

            // When
            var id = await _createHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.Null(id);
        }

        [Fact]
        public async Task CreateGemeenteCommandHandler_Should_Return_GemeenteId_When_GemeenteId_Dont_Exists()
        {
            // Given
            var command = new CreateGemeenteCommand
            {
                Postcode = "3582",
                Stad = "Koersel"
            };

            // When
            var id = await _createHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Guid>(id);
        }

        [Fact]
        public async Task CreateGemeenteCommandHandler_Should_Return_GemeenteId_When_GemeenteId_Exists()
        {
            // Given
            var command = new CreateGemeenteCommand
            {
                Postcode = "3580",
                Stad = "Beringen"
            };

            // When
            var id = await _createHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Guid>(id);
        }
    }
}
