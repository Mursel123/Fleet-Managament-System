using FMA.Application.DTOs.SubDTOS;
using FMA.Application.DTOs.Tankkaarten;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Chauffeurs
{
    public class ChauffeurDTO
    {
        public Guid Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Voornaam { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Geboortedatum { get; set; }
        public string Rijksregisternummer { get; set; } = string.Empty;
        public bool IsActief { get; set; } = true;

        public virtual ChauffeurTankkaartDTO Tankkaart { get; set; }
        public virtual AdresDTO? Adres { get; set; }
        public virtual GemeenteDTO? Gemeente { get; init; }
        public Geslacht Geslacht { get; set; }
        public RijbewijsType? RijbewijsType { get; set; }
        public virtual List<GemeldeSchadeDTO> GemeldeSchades { get; init; }
    }
}
