using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FMA.Application.Queries.Tankkaarten.ReadTankkaartList
{
    public class ReadTankkaartListQueryHandler : IRequestHandler<ReadTankkaartListQuery, List<TankkaartListDTO>>
    {
        private readonly IWriteDbContext _context;
        private readonly IMapper _mapper;

        public ReadTankkaartListQueryHandler(IWriteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TankkaartListDTO>> Handle(ReadTankkaartListQuery request, CancellationToken ct)
        {
            return await _context.Set<Domain.Entities.Tankkaart>()
            .ProjectTo<TankkaartListDTO>(_mapper.ConfigurationProvider).TagWith("Read All Tankkaarten")
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        }
    }
}
