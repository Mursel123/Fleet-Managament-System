using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Onderhouden.Create
{
    public class CreateOnderhoudCommand : IRequest<Guid>
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public string FileName { get; set; }
        public string UitgevoerdeWerken { get; set; } = string.Empty;
        public byte[] FileData { get; set; }
        public BestandType BestandType { get; set; }
        public Guid AanvraagId { get; set; }
        public Guid VoertuigId { get; set; }
        public Guid? GarageId { get; set; }

    }
}
