﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Onderhoud : BaseEntity
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public string UitgevoerdeWerken { get; set; } = string.Empty;

        public virtual Aanvraag Aanvraag { get; set; }
        public virtual Voertuig Voertuig { get; set; }
        public virtual Document Document { get; init; }
        public virtual Garage? Garage { get; set; }
        
    }
}
