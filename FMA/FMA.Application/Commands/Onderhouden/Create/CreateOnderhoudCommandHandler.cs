using AutoMapper;
using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Application.Exceptions;
using FMA.Domain.Entities;
using MediatR;
using FMA.Application.Commands.Facturen.Create;

namespace FMA.Application.Commands.Onderhouden.Create
{
    public class CreateOnderhoudCommandHandler : IRequestHandler<CreateOnderhoudCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IWriteDbContext _writeContext;
        private readonly IValidator<CreateOnderhoudCommand> _validator;
        private readonly IMediator _mediator;
        public CreateOnderhoudCommandHandler(IMapper mapper, IValidator<CreateOnderhoudCommand> validator, IWriteDbContext writeContext, IMediator mediator)
        {
            _mapper = mapper;
            _validator = validator;
            _writeContext = writeContext;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateOnderhoudCommand request, CancellationToken ct)
        {
           
            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);

            var onderhoud = _mapper.Map<Onderhoud>(request);

            //Creating the document here because of one to one relationship.
            var documentId = await _mediator.Send(new CreateDocumentCommand() { FileData = request.FileData, BestandType = request.BestandType, FileName = request.FileName }, ct);

            var onderhoudEntry = _writeContext.Set<Onderhoud>().Entry(onderhoud);

            onderhoudEntry.Property("VoertuigId").CurrentValue = request.VoertuigId;
            onderhoudEntry.Property("GarageId").CurrentValue = request.GarageId;
            onderhoudEntry.Property("DocumentId").CurrentValue = documentId;

            await _writeContext.Set<Onderhoud>().AddAsync(onderhoud, ct);
            await _writeContext.SaveChangesAsync(ct);
            return onderhoud.Id;
        }
    }
}
