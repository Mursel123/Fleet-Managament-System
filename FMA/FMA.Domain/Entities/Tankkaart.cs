using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Tankkaart : BaseEntity
    {
        public string KaartNummer { get; set; } = string.Empty;
        public DateTime GeldigheidsDatum { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public bool IsGeblokkeerd { get; set; } = false;

        public BrandstofType? BrandstofType { get; set; }
        public AuthenticatieType? AuthenticatieType { get; set; }

        public virtual List<Chauffeur> Chauffeurs { get; init; }
        public virtual List<Service> Services { get; init; }
    }
}
