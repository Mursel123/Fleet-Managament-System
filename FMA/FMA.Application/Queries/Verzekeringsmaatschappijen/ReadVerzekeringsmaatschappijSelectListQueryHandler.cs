using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Application.DTOs.Verzekeringsmaatschappijen;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.Verzekeringsmaatschappijen
{
    public class ReadVerzekeringsmaatschappijSelectListQueryHandler : IRequestHandler<ReadVerzekeringsmaatschappijSelectListQuery, List<VerzekeringsmaatschappijSelectListDTO>>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadVerzekeringsmaatschappijSelectListQueryHandler(IReadDbContext readContext, IMapper mapper)
        {
            _readContext = readContext;
            _mapper = mapper;
        }

        public async Task<List<VerzekeringsmaatschappijSelectListDTO>> Handle(ReadVerzekeringsmaatschappijSelectListQuery request, CancellationToken ct)
        {
            return await _readContext.Query<Verzekeringsmaatschappij>()
                    .ProjectTo<VerzekeringsmaatschappijSelectListDTO>(_mapper.ConfigurationProvider)
                    .TagWith("Read All Verzkeringsmaatschappijen Select List")
                    .OrderBy(x => x.Id)
                    .ToListAsync(ct);
        }
    }
}
