using FMA.Application.DTOs.Chauffeurs;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Aanvragen
{
    public class AanvraagDTO
    {
        public Guid Id { get; set; }
        public DateTime DatumAanvraag { get; set; } 
        public DateTime BeginPeriode { get; set; }
        public DateTime EindPeriode { get; set; }
        public string Beschrijving { get; set; } = string.Empty;
        public virtual AanvraagOnderhoudDTO Onderhoud { get; set; }
        public virtual AanvraagHerstellingDTO Herstelling { get; set; }
        public virtual AanvraagChauffeurDTO Chauffeur { get; set; }
        public virtual AanvraagVoertuigDTO? Voertuig { get; set; }
        public AanvraagType AanvraagType { get; set; }
        public StatusType StatusType { get; set; }
    }
}
