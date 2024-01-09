using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Voertuig : BaseEntity
    {
        public string Chassisnummer { get; set; } = string.Empty;
        public DateTime StartLeasing { get; set; }
        public DateTime EersteInschrijving { get; set; }
        public DateTime LooptijdLeasing { get; set; }

        public WagenType WagenType { get; set; }
        public BrandstofType BrandstofType { get; set; }

        public virtual List<Chauffeur> Chauffeurs { get; set; }
        public virtual List<Nummerplaat> Nummerplaten { get; init; }
        public virtual List<Kilometerstand> Kilometerstanden { get; init; }
        public virtual List<Inspectieverslag> Inspectieverslagen { get; init; }
        public virtual List<Aanvraag> Aanvragen { get; init; }
        public virtual List<GemeldeSchade> GemeldeSchades { get; init; }
        public virtual List<Herstelling> Herstellingen { get; init; }
        public virtual List<Onderhoud> Onderhouden { get; init; }
    }
}
