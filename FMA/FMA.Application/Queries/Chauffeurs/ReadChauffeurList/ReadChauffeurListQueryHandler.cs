using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Chauffeurs;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.Chauffeurs.ReadChauffeurList
{
    public class ReadChauffeurListQueryHandler : IRequestHandler<ReadChauffeurListQuery, List<ChauffeurListDTO>>
    {
        private readonly IReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public ReadChauffeurListQueryHandler(IMapper mapper, IReadDbContext readDbContext)
        {
            _mapper = mapper;
            _readDbContext = readDbContext;
        }
        public async Task<List<ChauffeurListDTO>> Handle(ReadChauffeurListQuery request, CancellationToken ct)
        {
            return await _readDbContext.Query<Chauffeur>()
            .ProjectTo<ChauffeurListDTO>(_mapper.ConfigurationProvider)
            .TagWith("Read All Chauffeurs")
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        }
    }
}
