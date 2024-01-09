using FMA.Application.DTOs.Voertuigen;
using MediatR;

namespace FMA.Application.Queries.Voertuigen.GetVoertuigDetail
{
    public class ReadVoertuigDetailQuery : IRequest<VoertuigDTO>
    {
        public Guid Id { get; set; }
    }
}
