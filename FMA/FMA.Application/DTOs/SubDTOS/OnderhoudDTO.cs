using FMA.Application.DTOs.Voertuigen;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class OnderhoudDTO
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public virtual VoertuigDTO Voertuig { get; set; }
        public virtual DocumentDTO? Document { get; set; }
        public virtual GarageDTO? Garage { get; set; }
        public string UitgevoerdeWerken { get; set; } = string.Empty;
    }
}
