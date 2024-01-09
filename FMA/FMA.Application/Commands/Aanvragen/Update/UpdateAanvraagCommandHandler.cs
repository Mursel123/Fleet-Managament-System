using AutoMapper;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Application.Exceptions;
using FMA.Contracts.Persistence;
using FMA.Domain.Config;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Aanvragen.Update
{
    public class UpdateAanvraagCommandHandler : IRequestHandler<UpdateAanvraagCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly SignalR _optionsSignalR;
        public UpdateAanvraagCommandHandler(IWriteDbContext writeContext, IMapper mapper, IHubContext<NotificationHub> hubContext, IOptions<SignalR> optionsSignalR)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _hubContext = hubContext;
            _optionsSignalR = optionsSignalR.Value;
        }
        public async Task<Guid> Handle(UpdateAanvraagCommand request, CancellationToken ct)
        {
            var aanvraag = new Aanvraag();

            int updatedRows = 0;

            if (request.OnderhoudId is not null)
            {
                updatedRows = await _writeContext.Set<Aanvraag>()
                    .Where(x => x.Id == request.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(x => EF.Property<Guid?>(x, "OnderhoudId"), request.OnderhoudId)
                        .SetProperty(x => x.LastModifiedDate, aanvraag.LastModifiedDate), ct);
            }
            else if (request.HerstellingId is not null)
            {
                updatedRows = await _writeContext.Set<Aanvraag>()
                    .Where(x => x.Id == request.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(x => EF.Property<Guid?>(x, "HerstellingId"), request.HerstellingId)
                        .SetProperty(x => x.LastModifiedDate, aanvraag.LastModifiedDate), ct);
            }

            if (updatedRows is 0)
                throw new NotFoundException($"{nameof(Aanvraag)} {request.Id} is niet gevonden.");
            await _hubContext.Clients.All.SendAsync(_optionsSignalR.Hub.Method.Name, "Aanvraag data updated.");
            return aanvraag.Id;

        }
    }
}
