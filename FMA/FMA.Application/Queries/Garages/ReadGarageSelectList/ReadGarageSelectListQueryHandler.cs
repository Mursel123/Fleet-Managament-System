using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Application.DTOs.Garages;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FMA.Application.Queries.Garages.ReadGarageSelectList
{
    public class ReadGarageSelectListQueryHandler : IRequestHandler<ReadGarageSelectListQuery, List<GarageSelectListDTO>>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadGarageSelectListQueryHandler(IReadDbContext readContext, IMapper mapper)
        {
            _readContext = readContext;
            _mapper = mapper;
        }

        public async Task<List<GarageSelectListDTO>> Handle(ReadGarageSelectListQuery request, CancellationToken ct)
        {
            return await _readContext.Query<Garage>()
                    .ProjectTo<GarageSelectListDTO>(_mapper.ConfigurationProvider)
                    .TagWith("Read All Garages Select List")
                    .OrderBy(x => x.Id)
                    .ToListAsync(ct);
        }
    }
}
