using FMA.Application.DTOs.Tankkaarten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Tankkaarten.ReadTankkaartList
{
    public record ReadTankkaartListQuery : IRequest<List<TankkaartListDTO>>;

}
