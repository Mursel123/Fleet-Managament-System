using AutoMapper;
using AutoMapper.QueryableExtensions;
using FMA.Contracts.Persistence;
using FMA.Application.DTOs.Aanvragen;
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

namespace FMA.Application.Queries.Aanvragen.ReadAanvraagDetail
{
    public class ReadAanvraagDetailQueryHandler : IRequestHandler<ReadAanvraagDetailQuery, AanvraagDTO>
    {
        private readonly IReadDbContext _readContext;
        private readonly IMapper _mapper;

        public ReadAanvraagDetailQueryHandler(IReadDbContext context, IMapper mapper)
        {
            _readContext = context;
            _mapper = mapper;
        }
        public async Task<AanvraagDTO> Handle(ReadAanvraagDetailQuery request, CancellationToken ct)
        {
            var aanvraag = await _readContext.Query<Aanvraag>()
                .ProjectTo<AanvraagDTO>(_mapper.ConfigurationProvider)
                .TagWith("Read Aanvraag By Id")
                .SingleOrDefaultAsync(x => x.Id == request.Id, ct);

            if (aanvraag is null)
                throw new NotFoundException($"{nameof(Aanvraag)} {request.Id} is niet gevonden."); ;

            return aanvraag;
        }
    }
}
