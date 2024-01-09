using FMA.Application.DTOs.Chauffeurs;
using MediatR;

namespace FMA.Application.Queries.Chauffeurs.ReadChauffeurList
{
    public class ReadChauffeurListQuery : IRequest<List<ChauffeurListDTO>>
    {
    }
}
