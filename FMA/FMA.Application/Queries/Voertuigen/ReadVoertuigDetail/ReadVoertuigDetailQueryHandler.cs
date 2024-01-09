using FMA.Application.DTOs.Voertuigen;
using FMA.Application.Exceptions;
using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using MediatR;

namespace FMA.Application.Queries.Voertuigen.GetVoertuigDetail
{
    public class ReadVoertuigDetailQueryHandler : IRequestHandler<ReadVoertuigDetailQuery, VoertuigDTO>
    {
        private readonly IBaseRepository<Voertuig> _baseRepo;

        public ReadVoertuigDetailQueryHandler(IBaseRepository<Voertuig> baseRepo)
        {
            _baseRepo = baseRepo;
        }
        public async Task<VoertuigDTO> Handle(ReadVoertuigDetailQuery request, CancellationToken ct)
        {
            var voertuig = await _baseRepo.GetByIdAsync<VoertuigDTO>(request.Id, ct);

            if (voertuig is null)
                throw new NotFoundException($"{nameof(Voertuig)} {request.Id} is niet gevonden."); ;

            return voertuig;
        }
    }
}
