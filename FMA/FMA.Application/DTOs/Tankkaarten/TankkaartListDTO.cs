
using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using FMA.Domain.Enums;

namespace FMA.Application.DTOs.Tankkaarten
{
    public class TankkaartListDTO
    {
        public Guid Id { get; set; }
        public string KaartNummer { get; set; } = string.Empty;
        public DateTime GeldigheidsDatum { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public AuthenticatieType AuthenticatieType { get; set; }
        public BrandstofType BrandstofType { get; set; }
        public bool IsGeblokkeerd { get; set; }
        

    }
}
