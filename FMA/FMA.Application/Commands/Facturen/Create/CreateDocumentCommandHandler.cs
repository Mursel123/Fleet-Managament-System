using AutoMapper;
using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Facturen.Create
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Guid>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IValidator<CreateDocumentCommand> _validator;
        private readonly IMapper _mapper;

        public CreateDocumentCommandHandler(IWriteDbContext writeContext, IValidator<CreateDocumentCommand> validator, IMapper mapper)
        {
            _writeContext = writeContext;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateDocumentCommand request, CancellationToken ct)
        {
            var validatorResult = await _validator.ValidateAsync(request, ct);

            if (validatorResult.Errors.Any())
                throw new Exceptions.ValidationException(validatorResult);


            var document = _mapper.Map<Document>(request);

            await _writeContext.Set<Document>().AddAsync(document, ct);
            await _writeContext.SaveChangesAsync(ct);

            return document.Id;
        }
    }
}
