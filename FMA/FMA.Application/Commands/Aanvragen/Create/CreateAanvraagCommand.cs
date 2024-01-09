using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Aanvragen.Create
{
    public class CreateAanvraagCommand : IRequest<Guid>
    {
        public DateTime BeginPeriode { get; set; }
        public DateTime EindPeriode { get; set; }
        public string Beschrijving { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public Guid? VoertuigId { get; set; }
        public AanvraagType AanvraagType { get; set; }
    }
}
