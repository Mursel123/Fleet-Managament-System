using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Herstelling : BaseEntity
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public virtual Aanvraag Aanvraag { get; set; }
        public virtual Voertuig Voertuig { get; set; }
        public virtual Verzekeringsmaatschappij Verzekeringsmaatschappij { get; set; }
        public virtual GemeldeSchade? GemeldeSchade { get; set; }
        public virtual List<Document> Documenten { get; init; }



    }
}
