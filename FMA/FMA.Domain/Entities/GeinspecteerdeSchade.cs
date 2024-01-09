using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class GeinspecteerdeSchade : BaseEntity
    {
        public string Onderdeel { get; set; } = string.Empty;
        public string Schade { get; set; } = string.Empty;
        public decimal Kostprijs { get; set; }

        public virtual Inspectieverslag Inspectieverslag { get; init; }
        public virtual HerstellingType? HerstellingType { get; init; }
        public virtual GemeldeSchade? GemeldeSchade { get; init; }
    }
}
