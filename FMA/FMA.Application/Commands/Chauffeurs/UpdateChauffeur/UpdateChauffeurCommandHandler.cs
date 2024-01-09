using AutoMapper;
using FluentValidation;
using FMA.Application.Exceptions;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Commands.Chauffeurs.UpdateChauffeur
{
    public class UpdateChauffeurCommandHandler : IRequestHandler<UpdateChauffeurCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateChauffeurCommand> _validator;

        public UpdateChauffeurCommandHandler(IWriteDbContext writeContext, IMapper mapper, IValidator<UpdateChauffeurCommand> validator)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<Guid> Handle(UpdateChauffeurCommand request, CancellationToken ct)
        {

            var chauffeur = _mapper.Map<Chauffeur>(request);

            int updatedRows = await _writeContext.Set<Chauffeur>()
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.Naam, request.Naam)
                    .SetProperty(x => x.Voornaam, request.Voornaam)
                    .SetProperty(x => x.IsActief, request.IsActief)
                    .SetProperty(x => EF.Property<Guid?>(x,"TankkaartId"), request.TankkaartId)
                    .SetProperty(x => EF.Property<Guid?>(x,"GemeenteId"), request.GemeenteId)
                    .SetProperty(x => x.RijbewijsType, request.RijbewijsType)
                    .SetProperty(x => x.LastModifiedDate, chauffeur.LastModifiedDate), ct);

            if (updatedRows is 0)
                throw new NotFoundException($"{nameof(Chauffeur)} {request.Id} is niet gevonden.");

            return chauffeur.Id;
        }
    }
}
