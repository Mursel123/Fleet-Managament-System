using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Chauffeurs
{
    public class AdresDTO
    {
        public string Straat { get; set; } = string.Empty;
        public string Nummer { get; set; } = string.Empty;
        public string Bus { get; set; } = string.Empty;
       
    }
}
