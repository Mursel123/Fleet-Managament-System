using AutoMapper;
using FluentValidation;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Gemeentes.Create
{
    public class CreateGemeenteCommandHandler : IRequestHandler<CreateGemeenteCommand, Guid?>
    {
        private readonly IWriteDbContext _writeContext;
        private readonly IValidator<CreateGemeenteCommand> _validator;

        public CreateGemeenteCommandHandler(IWriteDbContext writeContext, IValidator<CreateGemeenteCommand> validator)
        {
            _writeContext = writeContext;
            _validator = validator;
        }

        public async Task<Guid?> Handle(CreateGemeenteCommand request, CancellationToken ct)
        {
            if (!string.IsNullOrWhiteSpace(request.Postcode) && !string.IsNullOrWhiteSpace(request.Stad))
            {
                var validatorResult = await _validator.ValidateAsync(request, ct);

                if (validatorResult.Errors.Any())
                    throw new Exceptions.ValidationException(validatorResult);

                var gemeente = await _writeContext.Set<Gemeente>()
                    .AsTracking()
                    .SingleOrDefaultAsync(x => x.Postcode == request.Postcode && x.Stad == request.Stad.ToLower(), ct);

                if (gemeente is null)
                {
                    gemeente = new();
                    gemeente.Stad = request.Stad;
                    gemeente.Postcode = request.Postcode;
                    
                    await _writeContext.Set<Gemeente>().AddAsync(gemeente, ct);
                    await _writeContext.SaveChangesAsync(ct);
                }

                return gemeente.Id;
            }

            return null;
        }
    }
}
