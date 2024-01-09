using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Kilometerstand : BaseEntity
    {
        public string Stand { get; set; } = string.Empty;
        public DateTime Datum { get; set; }

        public virtual Voertuig Voertuig { get; set; }

    }
}
