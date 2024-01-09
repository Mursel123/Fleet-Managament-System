using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Gemeente : BaseEntity
    {
        public string Postcode { get; set; } = string.Empty;
        public string Stad { get; set; } = string.Empty;
        public virtual List<Chauffeur> Chauffeurs { get; init; }
        public virtual List<Verzekeringsmaatschappij> Verzekeringsmaatschappijen { get; init; }
        public virtual List<Garage> Garages { get; init; }
    }
}
