using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Aanvragen
{
    public class AanvraagVoertuigDTO
    {
        public Guid Id { get; set; }
        public string Chassisnummer { get; set; } = string.Empty;
        public WagenType WagenType { get; set; }
        public BrandstofType BrandstofType { get; set; }
    }
}
