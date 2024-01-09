using FMA.Application.DTOs.SubDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Chauffeurs
{
    public class ChauffeurTankkaartDTO
    {
        public Guid Id { get; set; }
        public string KaartNummer { get; set; } = string.Empty;
        public DateTime GeldigheidsDatum { get; set; }

    }
}
