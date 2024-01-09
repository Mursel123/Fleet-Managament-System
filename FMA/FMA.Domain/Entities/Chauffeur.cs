using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Chauffeur : BaseEntity
    {
        public string Naam { get; set; } = string.Empty;
        public string Voornaam { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Geboortedatum { get; set; }
        public string Rijksregisternummer { get; set; } = string.Empty;
        public bool IsActief { get; set; } = true;
        public RijbewijsType? RijbewijsType { get; set; }
        
        public Geslacht Geslacht { get; set; }

        public virtual Tankkaart? Tankkaart { get; set; }
        public virtual Adres? Adres { get; set; }
        public virtual Gemeente? Gemeente { get; init; }
        public virtual List<Voertuig> Voertuigen { get; set; }
        public virtual List<Aanvraag> Aanvragen { get; init; }
        public virtual List<Inspectieverslag> Inspectieverslagen { get; init; }
        public virtual List<GemeldeSchade> GemeldeSchades { get; init; }

    }
}
