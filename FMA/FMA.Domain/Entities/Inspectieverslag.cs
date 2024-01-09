using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Inspectieverslag : BaseEntity
    {
        public DateTime DatumUitvoering { get; set; }
        public bool ChauffeurAanwezig { get; set; }
        public decimal TotaalKost { get; set; }
        public string Verslag { get; set; } = string.Empty;

        public virtual Chauffeur Chauffeur { get; set; }
        public virtual Voertuig Voertuig { get; set; }
        public virtual List<GeinspecteerdeSchade> GeinspecteerdeSchades { get; init; }

    }
}
