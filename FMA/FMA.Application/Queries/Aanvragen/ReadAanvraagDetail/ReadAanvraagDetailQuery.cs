using FMA.Application.DTOs.Aanvragen;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Aanvragen.ReadAanvraagDetail
{
    public class ReadAanvraagDetailQuery : IRequest<AanvraagDTO>
    {
        public Guid Id { get; set; }
    }
}
