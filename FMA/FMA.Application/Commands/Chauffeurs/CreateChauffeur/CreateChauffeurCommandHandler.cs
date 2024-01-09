using AutoMapper;
using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Domain.Config;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;

namespace FMA.Application.Commands.Chauffeurs.CreateChauffeur
{
    public class CreateChauffeurCommandHandler : IRequestHandler<CreateChauffeurCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateChauffeurCommand> _validator;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly SignalR _optionsSignalR;

        public CreateChauffeurCommandHandler(IWriteDbContext writeContext, IMapper mapper, IValidator<CreateChauffeurCommand> validator, IHubContext<NotificationHub> hubContext, IOptions<SignalR> optionsSignalR)
        {
            _writeContext = writeContext;
            _mapper = mapper;
            _validator = validator;
            _hubContext = hubContext;
            _optionsSignalR = optionsSignalR.Value;
        }

        public async Task<Guid> Handle(CreateChauffeurCommand request, CancellationToken ct)
        {
           
            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);


            var chauffeur = _mapper.Map<Chauffeur>(request);

            var chauffeurEntry = _writeContext.Set<Chauffeur>().Entry(chauffeur);

            chauffeurEntry.Property("TankkaartId").CurrentValue = request.TankkaartId;
            chauffeurEntry.Property("GemeenteId").CurrentValue = request.GemeenteId;

            await _writeContext.Set<Chauffeur>().AddAsync(chauffeur, ct);
            await _writeContext.SaveChangesAsync(ct);

            await _hubContext.Clients.All.SendAsync(_optionsSignalR.Hub.Method.Name, "Chauffeur data updated.");

            return chauffeur.Id;
        }
    }
}
