using FMA.Application.DTOs.Voertuigen;
using MediatR;

namespace FMA.Application.Queries.Voertuigen.ReadVoertuigList
{
    public class ReadVoertuigListQuery : IRequest<List<VoertuigListDTO>>
    {
    }
}
