using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Type { get; set; } = string.Empty;

        public virtual List<Tankkaart> Tankkaarten { get; init; }
    }
}
