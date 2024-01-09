using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Aanvragen;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Aanvragen.ReadAanvraagNotification
{
    public class ReadAanvraagNotificationQueryHandler : IRequestHandler<ReadAanvraagNotificationQuery, List<AanvraagNotificationListDTO>>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadAanvraagNotificationQueryHandler(IReadDbContext readContext, IMapper mapper)
        {
            _readContext = readContext;
            _mapper = mapper;
        }

        public async Task<List<AanvraagNotificationListDTO>> Handle(ReadAanvraagNotificationQuery request, CancellationToken ct)
        {
            return await _readContext.Query<Aanvraag>()
            .Where(x => (x.AanvraagType == AanvraagType.Onderhoud && x.Onderhoud == null && x.Chauffeur.Email == request.Email && x.StatusType == StatusType.Goedgekeurd) ||
                        (x.AanvraagType == AanvraagType.Herstelling && x.Herstelling == null && x.Chauffeur.Email == request.Email && x.StatusType == StatusType.Goedgekeurd))
            .ProjectTo<AanvraagNotificationListDTO>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        }
    }
}
