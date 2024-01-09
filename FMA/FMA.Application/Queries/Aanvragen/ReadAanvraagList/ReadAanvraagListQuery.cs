using FMA.Application.DTOs.Aanvragen;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Aanvragen.ReadAanvraagList
{
    public class ReadAanvraagListQuery : IRequest<List<AanvraagDTO>>
    {
        public string Email { get; set; } = string.Empty;
        public bool InBehandeling { get; set; }
    }
}
