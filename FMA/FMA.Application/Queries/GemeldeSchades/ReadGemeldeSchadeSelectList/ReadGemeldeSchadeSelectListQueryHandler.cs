using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Application.DTOs.GemeldeSchades;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.GemeldeSchades.ReadGemeldeSchadeSelectList
{
    public class ReadGemeldeSchadeSelectListQueryHandler : IRequestHandler<ReadGemeldeSchadeSelectListQuery, List<GemeldeSchadeSelectListDTO>>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadGemeldeSchadeSelectListQueryHandler(IReadDbContext readContext, IMapper mapper)
        {
            _readContext = readContext;
            _mapper = mapper;
        }

        public async Task<List<GemeldeSchadeSelectListDTO>> Handle(ReadGemeldeSchadeSelectListQuery request, CancellationToken ct)
        {
            return await _readContext.Query<GemeldeSchade>()
                    .ProjectTo<GemeldeSchadeSelectListDTO>(_mapper.ConfigurationProvider)
                    .TagWith("Read All Verzkeringsmaatschappijen Select List")
                    .OrderBy(x => x.DatumMelding)
                    .ToListAsync(ct);
        }
    }
}
