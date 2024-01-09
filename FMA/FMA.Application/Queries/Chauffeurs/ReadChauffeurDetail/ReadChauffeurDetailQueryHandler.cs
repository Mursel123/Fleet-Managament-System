using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.Exceptions;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.Chauffeurs.ReadChauffeurDetail
{
    public class ReadChauffeurDetailQueryHandler : IRequestHandler<ReadChauffeurDetailQuery, ChauffeurDTO>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadChauffeurDetailQueryHandler(IReadDbContext context, IMapper mapper)
        {
            _readContext = context;
            _mapper = mapper;
        }
        public async Task<ChauffeurDTO> Handle(ReadChauffeurDetailQuery request, CancellationToken ct)
        {
            var chauffeur = new ChauffeurDTO();

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                chauffeur = await _readContext.Query<Chauffeur>()
                .ProjectTo<ChauffeurDTO>(_mapper.ConfigurationProvider)
                .TagWith("Read Chauffeur By Id")
                .SingleOrDefaultAsync(x => x.Email == request.Email, ct);
            }
            else
            {
                chauffeur = await _readContext.Query<Chauffeur>()
                .ProjectTo<ChauffeurDTO>(_mapper.ConfigurationProvider)
                .TagWith("Read Chauffeur By Id")
                .SingleOrDefaultAsync(x => x.Id == request.Id, ct);
            }
            

            if (chauffeur is null)
                throw new NotFoundException($"{nameof(Chauffeur)} {request.Id} is niet gevonden."); ;

            return chauffeur;
        }
    }
}
