using FMA.Application.DTOs.Chauffeurs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Queries.Chauffeurs.ReadChauffeurDetail
{
    public class ReadChauffeurDetailQuery : IRequest<ChauffeurDTO>
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
