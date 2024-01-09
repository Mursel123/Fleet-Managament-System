
using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.DTOs.Voertuigen;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class InspectieverslagDTO
    {
        public Guid Id { get; set; }
        public DateTime DatumUitvoering { get; set; }
        public bool ChauffeurAanwezig { get; set; }
        public decimal TotaalKost { get; set; }
        public string Verslag { get; set; } = string.Empty;

        public virtual ChauffeurDTO Chauffeur { get; set; }
        public virtual VoertuigDTO Voertuig { get; set; }
        public virtual List<GeinspecteerdeSchadeDTO> GeinspecteerdeSchades { get; init; }
    }
}
