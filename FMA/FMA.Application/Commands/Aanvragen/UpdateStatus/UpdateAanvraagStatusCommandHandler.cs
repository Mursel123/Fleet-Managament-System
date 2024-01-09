using AutoMapper;
using FMA.Application.Exceptions;
using FMA.Contracts.Persistence;
using FMA.Domain.Config;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FMA.Application.Commands.Aanvragen.UpdateStatus
{
    public class UpdateAanvraagStatusCommandHandler : IRequestHandler<UpdateAanvraagStatusCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly SignalR _optionsSignalR;
        public UpdateAanvraagStatusCommandHandler(IWriteDbContext writeContext, IMapper mapper, IHubContext<NotificationHub> hubContext, IOptions<SignalR> optionsSignalR)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _hubContext = hubContext;
            _optionsSignalR = optionsSignalR.Value;
        }
        public async Task<Guid> Handle(UpdateAanvraagStatusCommand request, CancellationToken ct)
        {
            var aanvraag = _mapper.Map<Aanvraag>(request);

            int updatedRows = await _writeContext.Set<Aanvraag>()
                .Where(x => x.Id == request.Id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(x => x.StatusType, request.StatusType)
                    .SetProperty(x => x.LastModifiedDate, aanvraag.LastModifiedDate), ct);

            if (updatedRows is 0)
                throw new NotFoundException($"{nameof(Aanvraag)} {request.Id} is niet gevonden.");
            await _hubContext.Clients.All.SendAsync(_optionsSignalR.Hub.Method.Name, "Aanvraag data updated.");
            return aanvraag.Id;
        }
    }
}
