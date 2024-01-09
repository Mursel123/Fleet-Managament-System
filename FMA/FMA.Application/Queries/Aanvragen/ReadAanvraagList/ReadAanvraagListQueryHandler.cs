using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Aanvragen;
using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Application.Exceptions;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Aanvragen.ReadAanvraagList
{
    public class ReadAanvraagListQueryHandler : IRequestHandler<ReadAanvraagListQuery, List<AanvraagDTO>>
    {
        private readonly IReadDbContext _readDbContext;
        private readonly IMapper _mapper;
        public ReadAanvraagListQueryHandler(IReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }
        public async Task<List<AanvraagDTO>> Handle(ReadAanvraagListQuery request, CancellationToken ct)
        {
            if (!string.IsNullOrWhiteSpace(request.Email)) 
            {
                return await _readDbContext.Query<Aanvraag>()
                .ProjectTo<AanvraagDTO>(_mapper.ConfigurationProvider)
                .Where(x => x.Chauffeur.Email == request.Email)
                .TagWith("Read All Aanvragen")
                .OrderBy(x => x.DatumAanvraag)
                .ToListAsync(ct);
            }

            if (request.InBehandeling)
            {
                return await _readDbContext.Query<Aanvraag>()
                .ProjectTo<AanvraagDTO>(_mapper.ConfigurationProvider)
                .Where(x => x.StatusType == Domain.Enums.StatusType.InBehandeling)
                .TagWith("Read All Aanvragen")
                .OrderBy(x => x.DatumAanvraag)
                .ToListAsync(ct);
            }
            else
            {
                return await _readDbContext.Query<Aanvraag>()
                .ProjectTo<AanvraagDTO>(_mapper.ConfigurationProvider)
                .Where(x => x.StatusType != Domain.Enums.StatusType.InBehandeling)
                .TagWith("Read All Aanvragen")
                .OrderBy(x => x.DatumAanvraag)
                .ToListAsync(ct);
            }

        }
    }
}
