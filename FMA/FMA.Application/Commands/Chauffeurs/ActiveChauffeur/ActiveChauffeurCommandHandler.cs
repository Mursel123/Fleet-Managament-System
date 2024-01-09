using AutoMapper;
using FMA.Contracts.Persistence;
using FMA.Application.Exceptions;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Commands.Chauffeurs.ActiveChauffeur
{
    public class ActiveChauffeurCommandHandler : IRequestHandler<ActiveChauffeurCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;

        public ActiveChauffeurCommandHandler(IWriteDbContext writeContext, IMapper mapper)
        {
            _writeContext = writeContext;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(ActiveChauffeurCommand request, CancellationToken ct)
        {
            var chauffeur = new Chauffeur();

            int updatedRows = await _writeContext.Set<Chauffeur>()
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.IsActief, request.IsActive)
                    .SetProperty(x => x.LastModifiedDate, chauffeur.LastModifiedDate), ct) ;

            if (updatedRows is 0)
                throw new NotFoundException($"{nameof(Chauffeur)} {request.Id} is niet gevonden.");

            return request.Id;
        }
    }
}
