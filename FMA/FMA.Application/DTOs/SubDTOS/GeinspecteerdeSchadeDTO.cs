
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class GeinspecteerdeSchadeDTO
    {
        public Guid Id { get; set; }
        public string Onderdeel { get; set; } = string.Empty;
        public string Schade { get; set; } = string.Empty;
        public decimal Kostprijs { get; set; }

        public virtual HerstellingTypeDTO? HerstellingType { get; init; }
        public virtual GemeldeSchadeDTO? GemeldeSchade { get; init; }
    }
}
