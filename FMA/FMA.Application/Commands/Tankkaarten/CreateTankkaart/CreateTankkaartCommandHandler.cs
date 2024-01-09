using AutoMapper;
using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Application.Exceptions;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Commands.Tankkaarten.CreateTankkaart
{
    public class CreateTankkaartCommandHandler : IRequestHandler<CreateTankkaartCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTankkaartCommand> _validator;
        public CreateTankkaartCommandHandler(IWriteDbContext writeContext, IMapper mapper, IValidator<CreateTankkaartCommand> validator)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateTankkaartCommand request, CancellationToken ct)
        {

            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);


            var foundServices = await _writeContext.Set<Service>()
                .AsTracking()
                .Where(s => request.Services.Select(rs => rs.Id).Contains(s.Id))
                .ToListAsync(ct);

            var tankkaart = new Tankkaart() { Services = foundServices };

            _mapper.Map(request, tankkaart, typeof(CreateTankkaartCommand), typeof(Tankkaart));


            await _writeContext.Set<Tankkaart>().AddAsync(tankkaart, ct);
            await _writeContext.SaveChangesAsync(ct);

            return tankkaart.Id;

        }
    }
}
