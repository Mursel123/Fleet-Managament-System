using FMA.Application.DTOs.GemeldeSchades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.GemeldeSchades.ReadGemeldeSchadeSelectList
{
    public record ReadGemeldeSchadeSelectListQuery : IRequest<List<GemeldeSchadeSelectListDTO>> { }
}
