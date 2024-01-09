using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.Tankkaarten.ReadTankkaartSelectList
{
    public class ReadTankkaartSelectListQueryHandler : IRequestHandler<ReadTankkaartSelectListQuery, List<TankkaartSelectListDTO>>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadTankkaartSelectListQueryHandler(IReadDbContext readContext, IMapper mapper)
        {
            _readContext = readContext;
            _mapper = mapper;
        }
        public async Task<List<TankkaartSelectListDTO>> Handle(ReadTankkaartSelectListQuery request, CancellationToken ct)
        {
            return await _readContext.Query<Tankkaart>()
            .ProjectTo<TankkaartSelectListDTO>(_mapper.ConfigurationProvider)
            .TagWith("Read All Tankkaarten for select list")
            .OrderBy(x => x.Id)
            .ToListAsync(ct);
        }
    }
}
