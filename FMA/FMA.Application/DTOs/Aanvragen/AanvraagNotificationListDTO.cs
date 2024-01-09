using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Aanvragen
{
    public class AanvraagNotificationListDTO
    {
        public Guid Id { get; set; }
        public string Beschrijving { get; set; } = string.Empty;
        public AanvraagType AanvraagType { get; set; }
        public AanvraagVoertuigDTO Voertuig { get; set; }
    }
}
