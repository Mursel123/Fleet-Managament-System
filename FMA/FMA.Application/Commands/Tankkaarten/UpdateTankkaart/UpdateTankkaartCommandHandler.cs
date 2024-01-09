using AutoMapper;
using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Application.Exceptions;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Commands.Tankkaarten.UpdateTankkaart
{
    public class UpdateTankkaartCommandHandler : IRequestHandler<UpdateTankkaartCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTankkaartCommand> _validator;

        public UpdateTankkaartCommandHandler(IWriteDbContext writeContext, IMapper mapper, IValidator<UpdateTankkaartCommand> validator)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Guid> Handle(UpdateTankkaartCommand request, CancellationToken ct)
        {

            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);

            var tankkaart = _mapper.Map<Tankkaart>(request);

            int updatedRows = await _writeContext.Set<Tankkaart>()
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.GeldigheidsDatum, request.GeldigheidsDatum)
                    .SetProperty(x => x.Pincode, request.Pincode)
                    .SetProperty(x => x.AuthenticatieType, request.AuthenticatieType)
                    .SetProperty(x => x.BrandstofType, request.BrandstofType)
                    .SetProperty(x => x.LastModifiedDate, tankkaart.LastModifiedDate), ct);


            if (updatedRows is 0)
                throw new NotFoundException($"{nameof(Tankkaart)} {request.Id} is niet gevonden.");

            return tankkaart.Id;
        }
    }
}
