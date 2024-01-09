using AutoMapper;
using FluentValidation;
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

namespace FMA.Application.Commands.Aanvragen.Create
{
    public class CreateAanvraagCommandHandler : IRequestHandler<CreateAanvraagCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAanvraagCommand> _validator;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly SignalR _optionsSignalR;
        public CreateAanvraagCommandHandler(IWriteDbContext writeContext, IMapper mapper, IValidator<CreateAanvraagCommand> validator, IHubContext<NotificationHub> hubContext, IOptions<SignalR> optionsSignalR)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _validator = validator;
            _hubContext = hubContext;
            _optionsSignalR = optionsSignalR.Value;
        }
        public async Task<Guid> Handle(CreateAanvraagCommand request, CancellationToken ct)
        {
            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);


            var aanvraag = _mapper.Map<Aanvraag>(request);

            var aanvraagEntry = _writeContext.Set<Aanvraag>().Entry(aanvraag);

            var chauffeurId = await _writeContext.Set<Chauffeur>().Where(x => x.Email == request.Email).Select(x => x.Id).SingleAsync();

            aanvraagEntry.Property("ChauffeurId").CurrentValue = chauffeurId;
            aanvraagEntry.Property("VoertuigId").CurrentValue = request.VoertuigId;

            await _writeContext.Set<Aanvraag>().AddAsync(aanvraag, ct);
            await _writeContext.SaveChangesAsync(ct);

            await _hubContext.Clients.All.SendAsync(_optionsSignalR.Hub.Method.Name, "Aanvraag data updated.");

            return aanvraag.Id;
        }
    }
}
