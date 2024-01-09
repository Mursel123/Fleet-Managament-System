using FMA.Application.DTOs.Voertuigen;
using FMA.Contracts.Persistence;
using MediatR;

namespace FMA.Application.Queries.Voertuigen.ReadVoertuigSelectList
{
    public class ReadVoertuigSelectListQueryHandler : IRequestHandler<ReadVoertuigSelectListQuery, List<VoertuigSelectListDTO>>
    {
        private readonly IVoertuigRepository _voertuigRepo;
        public ReadVoertuigSelectListQueryHandler(IVoertuigRepository voertuigRepo)
        {
            _voertuigRepo = voertuigRepo;
        }
        public Task<List<VoertuigSelectListDTO>> Handle(ReadVoertuigSelectListQuery request, CancellationToken ct)
        {
            return _voertuigRepo.ReadVoertuigenSelectListAsync<VoertuigSelectListDTO>(ct);
        }
    }
}
