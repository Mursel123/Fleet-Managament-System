using AutoMapper;
using FluentValidation;
using FMA.Application.Commands.Facturen.Create;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Herstellingen.Create
{
    public class CreateHerstellingCommandHandler : IRequestHandler<CreateHerstellingCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateHerstellingCommand> _validator;
        public CreateHerstellingCommandHandler(IWriteDbContext writeContext, IMapper mapper, IValidator<CreateHerstellingCommand> validator)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateHerstellingCommand request, CancellationToken ct)
        {

            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);

            var herstelling = _mapper.Map<Herstelling>(request);

            var herstellingEntry = _writeContext.Set<Herstelling>().Entry(herstelling);

            herstellingEntry.Property("VoertuigId").CurrentValue = request.VoertuigId;
            herstellingEntry.Property("VerzekeringsmaatschappijId").CurrentValue = request.VerzekeringsmaatschappijId;
            herstellingEntry.Property("GemeldeSchadeId").CurrentValue = request.GemeldeSchadeId;

            await _writeContext.Set<Herstelling>().AddAsync(herstelling, ct);
            await _writeContext.SaveChangesAsync(ct);
            return herstelling.Id;
        }
    }
}
