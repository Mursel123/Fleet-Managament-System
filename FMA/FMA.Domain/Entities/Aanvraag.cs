using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Aanvraag : BaseEntity
    {
        public DateTime DatumAanvraag { get; } = DateTime.Now;
        public DateTime BeginPeriode { get; set; }
        public DateTime EindPeriode { get; set; }
        public string Beschrijving { get; set; } = string.Empty;

        public virtual Onderhoud? Onderhoud { get; set; }
        public virtual Herstelling? Herstelling { get; set; }
        public virtual Chauffeur Chauffeur { get; set; }
        public virtual Voertuig? Voertuig { get; set; }
        public AanvraagType AanvraagType { get; set; }
        public StatusType StatusType { get; set; } = StatusType.InBehandeling;
    }
}
