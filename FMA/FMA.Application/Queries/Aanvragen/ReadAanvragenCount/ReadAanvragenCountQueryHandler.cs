using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Aanvragen.ReadAanvragenCount
{
    public class ReadAanvragenCountQueryHandler : IRequestHandler<ReadAanvragenCountQuery, int>
    {
        private readonly IReadDbContext _readContext;
        public ReadAanvragenCountQueryHandler(IReadDbContext readContext)
        {
            _readContext = readContext;
        }
        public async Task<int> Handle(ReadAanvragenCountQuery request, CancellationToken ct)
        {
            return await _readContext.Query<Aanvraag>().CountAsync(x => x.StatusType == Domain.Enums.StatusType.InBehandeling, ct);
        }
    }
}
