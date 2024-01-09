using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Chauffeurs
{
    public class ChauffeurVoertuigDTO
    {
        public Guid Id { get; set; }
        public string Chassisnummer { get; set; } = string.Empty;
    }
}
