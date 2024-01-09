using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.Tankkaarten.ReadTankaartDetail
{
    public class ReadTankkaartDetailQueryHandler : IRequestHandler<ReadTankkaartDetailQuery, TankkaartDTO>
    {
        private readonly IWriteDbContext _context;
        private readonly IMapper _mapper;

        public ReadTankkaartDetailQueryHandler(IWriteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TankkaartDTO> Handle(ReadTankkaartDetailQuery request, CancellationToken ct)
        {
            var tankkaart = await _context.Set<Domain.Entities.Tankkaart>()
                .ProjectTo<TankkaartDTO>(_mapper.ConfigurationProvider)
                .TagWith("Read Tankkaart By Id")
                .SingleOrDefaultAsync(x => x.Id == request.Id, ct);

            if (tankkaart is null)
                throw new NotFoundException($"{nameof(Domain.Entities.Tankkaart)} {request.Id} is niet gevonden."); ;

            return tankkaart;
        }
    }
}
