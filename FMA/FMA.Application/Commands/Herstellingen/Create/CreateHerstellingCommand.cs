using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Herstellingen.Create
{
    public class CreateHerstellingCommand : IRequest<Guid>
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public Guid AanvraagId { get; set; }
        public Guid VoertuigId { get; set; }
        public Guid VerzekeringsmaatschappijId { get; set; }
        public Guid? GemeldeSchadeId { get; set; }

        public List<HerstellingDocumentDTO> Documenten { get; set; }
    }
}
