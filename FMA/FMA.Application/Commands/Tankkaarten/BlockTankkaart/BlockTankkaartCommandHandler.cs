using AutoMapper;
using FMA.Contracts.Persistence;
using FMA.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMA.Domain.Entities;

namespace FMA.Application.Commands.Tankkaarten.BlockTankkaart
{
    public class BlockTankkaartCommandHandler : IRequestHandler<BlockTankkaartCommand, Guid>
    {
        private readonly IWriteDbContext _context;
        private readonly IMapper _mapper;
        public BlockTankkaartCommandHandler(IWriteDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(BlockTankkaartCommand request, CancellationToken ct)
        {
           var tankkaart = new Tankkaart();

           var updatedRows = await _context.Set<Tankkaart>()
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.IsGeblokkeerd, true)
                .SetProperty(x => x.LastModifiedDate, tankkaart.LastModifiedDate), ct);

            if (updatedRows is 0)
                throw new NotFoundException($"{nameof(Tankkaart)} {request.Id} is niet gevonden.");

            return tankkaart.Id;
        }
    }
}
