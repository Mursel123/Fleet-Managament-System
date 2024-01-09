using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Tankkaarten
{
    public class TankkaartDTO
    {
        public Guid Id { get; set; }
        public string KaartNummer { get; set; } = string.Empty;
        public DateTime GeldigheidsDatum { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public bool IsGeblokkeerd { get; set; }
        public BrandstofType BrandstofType { get; set; }
        public AuthenticatieType AuthenticatieType { get; set; }
        public virtual List<ServiceDTO> Services { get; init; }

    }
}
