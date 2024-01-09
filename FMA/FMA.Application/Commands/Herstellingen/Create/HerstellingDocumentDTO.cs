using FMA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Herstellingen.Create
{
    public class HerstellingDocumentDTO
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public BestandType BestandType { get; set; }
    }
}
