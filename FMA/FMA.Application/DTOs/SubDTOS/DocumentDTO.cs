using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class DocumentDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileData { get; set; } = string.Empty;
        public virtual HerstellingDTO Herstelling { get; set; }
    }
}
