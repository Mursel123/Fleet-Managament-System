using FMA.Contracts.Persistence;
using FMA.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Tankkaarten.DeleteTankkaart
{
    public class DeleteTankkaartCommandHandler : IRequestHandler<DeleteTankkaartCommand>
    {
        private readonly IWriteDbContext _writeContext;
        public DeleteTankkaartCommandHandler(IWriteDbContext writeContext)
        {
            _writeContext = writeContext;
        }

        public async Task<Unit> Handle(DeleteTankkaartCommand request, CancellationToken ct)
        {
            var deletedRows = await _writeContext.Set<Domain.Entities.Tankkaart>().Where(x => x.Id == request.Id).ExecuteDeleteAsync(ct);

            if (deletedRows is 0)
                throw new NotFoundException($"{nameof(Domain.Entities.Tankkaart)} {request.Id} is niet gevonden.");

            return Unit.Value;
        }
    }
}
