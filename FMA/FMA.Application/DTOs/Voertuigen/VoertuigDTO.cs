
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Voertuigen
{
    public class VoertuigDTO
    {
        public Guid Id { get; set; }
        public string Chassisnummer { get; set; } = string.Empty;
        public DateTime StartLeasing { get; set; }
        public DateTime EersteInschrijving { get; set; }
        public DateTime LooptijdLeasing { get; set; }

        public virtual WagenType WagenType { get; set; }
        public virtual BrandstofType BrandstofType { get; set; }


    }
}
