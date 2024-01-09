using FMA.Application.DTOs.Voertuigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class KilometerstandDTO
    {
        public Guid Id { get; set; }
        public string Stand { get; set; } = string.Empty;
        public DateTime Datum { get; set; }
        public virtual VoertuigDTO Voertuig { get; set; }
    }
}
