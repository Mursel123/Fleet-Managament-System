using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Enums;

namespace FMA.Application.DTOs.Voertuigen
{
    public class VoertuigListDTO
    {
        public Guid Id { get; set; }
        public string Chassisnummer { get; set; } = string.Empty;
        public DateTime StartLeasing { get; set; }
        public DateTime EersteInschrijving { get; set; }
        public DateTime LooptijdLeasing { get; set; }
        public WagenType? WagenType { get; set; }
        public BrandstofType BrandstofType { get; set; }
        
    }
}
