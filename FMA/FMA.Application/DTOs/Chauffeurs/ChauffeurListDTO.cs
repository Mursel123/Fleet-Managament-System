
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Chauffeurs
{
    public class ChauffeurListDTO
    {
        public Guid Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Voornaam { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Geboortedatum { get; set; }
        public string Rijksregisternummer { get; set; } = string.Empty;
        public virtual AdresDTO? Adres { get; set; }
        public virtual GemeenteDTO? Gemeente { get; init; }
        public bool IsActief { get; set; }

    }
}
