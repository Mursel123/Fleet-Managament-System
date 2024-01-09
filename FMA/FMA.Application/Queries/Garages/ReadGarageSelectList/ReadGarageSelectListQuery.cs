using FMA.Application.DTOs.Garages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Garages.ReadGarageSelectList
{
    public record ReadGarageSelectListQuery : IRequest<List<GarageSelectListDTO>> { }

}
