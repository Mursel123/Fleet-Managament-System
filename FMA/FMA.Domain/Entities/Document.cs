using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Document : BaseEntity
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public BestandType BestandType { get; set; }
        public virtual Herstelling? Herstelling { get; set; }
        public virtual Onderhoud? Onderhoud { get; set; }
        public virtual GemeldeSchade? GemeldeSchade { get; set; }

    }
}
