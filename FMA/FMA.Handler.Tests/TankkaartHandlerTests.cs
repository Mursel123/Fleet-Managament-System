using FMA.Application.Commands.Tankkaarten.BlockTankkaart;
using FMA.Application.Commands.Tankkaarten.CreateTankkaart;
using FMA.Application.Commands.Tankkaarten.DeleteTankkaart;
using FMA.Application.Commands.Tankkaarten.UnblockTankkaart;
using FMA.Application.Commands.Tankkaarten.UpdateTankkaart;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Application.Exceptions;
using FMA.Application.Queries.Tankkaarten.ReadTankaartDetail;
using FMA.Application.Queries.Tankkaarten.ReadTankkaartList;
using MediatR;

namespace FMA.Handler.Tests
{
    public class TankkaartHandlerTests : IClassFixture<TestFixture>
    {
        private readonly CreateTankkaartCommandValidator _createValidator;
        private readonly UpdateTankkaartCommandValidator _updateValidator;
        private readonly CreateTankkaartCommandHandler _createHandler;
        private readonly UpdateTankkaartCommandHandler _updateHandler;
        private readonly ReadTankkaartDetailQueryHandler _readHandler;
        private readonly ReadTankkaartListQueryHandler _readListHandler;
        private readonly DeleteTankkaartCommandHandler _deleteHandler;
        private readonly UnblockTankkaartCommandHandler _unblockHandler;
        private readonly BlockTankkaartCommandHandler _blockHandler;
        public TankkaartHandlerTests(TestFixture fixture)
        {
            var context = fixture._context;
            var mapper = fixture._mapper;

            fixture.CreateSamples();

            _createValidator = new(context);
            _updateValidator = new();
            _createHandler = new(context, mapper, _createValidator);
            _updateHandler = new(context, mapper, _updateValidator);
            _readHandler = new(context, mapper);
            _readListHandler = new(context, mapper);
            _deleteHandler = new(context);
            _unblockHandler = new(context, mapper);
            _blockHandler = new(context, mapper);

        }

        [Fact]
        public async Task CreateTankkaartCommandHandler_Should_Throw_ValidationEXception_On_IsKaartnummerUnique()
        {
            // Given
            var command = new CreateTankkaartCommand
            {
                KaartNummer = "0215214852",
                GeldigheidsDatum = DateTime.Now.AddMonths(6),
                Pincode = "24563",
                Services = new()
            };

            // When
            var action = () => _createHandler.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<Application.Exceptions.ValidationException>(action);

            // Then
            Assert.Contains("Kaart Nummer is al in gebruik.", exception.ReadErrors());
        }

        [Fact]
        public async Task CreateTankkaartCommandHandler_Should_Throw_ValidationEXception_On_Geldigheidsdatum()
        {
            // Given
            var command = new CreateTankkaartCommand
            {
                KaartNummer = "3145795156",
                GeldigheidsDatum = DateTime.Now.AddMonths(-6),
                Pincode = "24563",
                Services = new()
            };


            // When
            var action = () => _createHandler.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<Application.Exceptions.ValidationException>(action);

            // Then
            Assert.Contains("Geldigheids Datum mag niet in het verleden liggen.", exception.ReadErrors());
        }

        [Fact]
        public async Task CreateTankkaartCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new CreateTankkaartCommand
            {
                KaartNummer = "3145795156",
                GeldigheidsDatum = DateTime.Now.AddMonths(6),
                Pincode = "24563",
                Services = new()
            };

            // When
            var value = await _createHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Guid>(value);
        }

        [Fact]
        public async Task ReadTankkaartDetailQueryHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var query = new ReadTankkaartDetailQuery { Id = Guid.NewGuid() };

            // When
            var action = () => _readHandler.Handle(query, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task ReadTankkaartDetailQueryHandler_Should_Return_TankkaartDTO_When_Success()
        {
            // Given
            var query = new ReadTankkaartDetailQuery { Id = Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08") };

            // When
            var tankkaart = await _readHandler.Handle(query, CancellationToken.None);

            // Then
            Assert.IsType<TankkaartDTO>(tankkaart);
        }

        [Fact]
        public async Task ReadTankkaartListQueryHandler_Should_Return_TankkaartListDTO()
        {

            // Given en When
            var tankkaartList = await _readListHandler.Handle(new ReadTankkaartListQuery(), CancellationToken.None);

            // Then
            Assert.IsType<List<TankkaartListDTO>>(tankkaartList);
        }

        [Fact]
        public async Task UpdateTankkaartCommandHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var command = new UpdateTankkaartCommand { Id = Guid.NewGuid(), GeldigheidsDatum = DateTime.Now, Pincode = "651989" };

            // When
            var action = () => _updateHandler.Handle(command, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task UpdateTankkaartCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new UpdateTankkaartCommand { Id = Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08"), GeldigheidsDatum = DateTime.Now, Pincode = "651989" };

            // When
            var value = await _updateHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Guid>(value);
        }

        [Fact]
        public async Task DeleteTankkaartCommandHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var command = new DeleteTankkaartCommand { Id = Guid.NewGuid() };

            // When
            var action = () => _deleteHandler.Handle(command, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task DeleteTankkaartCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new DeleteTankkaartCommand { Id = Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08") };

            // When
            var unitValue = await _deleteHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Unit>(unitValue);
        }

        [Fact]
        public async Task BlockTankkaartCommandHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var command = new BlockTankkaartCommand { Id = Guid.NewGuid() };

            // When
            var action = () => _blockHandler.Handle(command, CancellationToken.None);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task BlockTankkaartCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new BlockTankkaartCommand { Id = Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08") };

            // When
            var value = await _blockHandler.Handle(command, CancellationToken.None);

            // Then
            Assert.IsType<Guid>(value);
        }
        [Fact]
        public async Task UnblockTankkaartCommandHandler_Should_Throw_KeyNotFoundException_When_Id_IsNotFound()
        {
            // Given
            var command = new UnblockTankkaartCommand { Id = Guid.NewGuid() };

            // When
            var action = () => _unblockHandler.Handle(command, default);

            // Then
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task UnblockTankkaartCommandHandler_Should_Return_UnitValue_When_Success()
        {
            // Given
            var command = new UnblockTankkaartCommand { Id = Guid.Parse("820C30BE-877D-46CF-8C30-5F97E9F03C08") };

            // When
            var value = await _unblockHandler.Handle(command, default);

            // Then
            Assert.IsType<Guid>(value);
        }

    }
}
