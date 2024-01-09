using FMA.Application.DTOs.Voertuigen;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Voertuigen.ReadVoertuigSelectList
{
    public class ReadVoertuigSelectListQuery : IRequest<List<VoertuigSelectListDTO>>
    {
    }
}
