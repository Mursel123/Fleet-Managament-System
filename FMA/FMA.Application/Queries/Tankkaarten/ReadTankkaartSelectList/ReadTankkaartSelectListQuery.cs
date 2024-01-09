using FMA.Application.DTOs.Tankkaarten;
using MediatR;

namespace FMA.Application.Queries.Tankkaarten.ReadTankkaartSelectList
{
    public class ReadTankkaartSelectListQuery : IRequest<List<TankkaartSelectListDTO>>
    {
    }
}
