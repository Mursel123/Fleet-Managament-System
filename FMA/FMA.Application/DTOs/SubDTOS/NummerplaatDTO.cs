using FMA.Application.DTOs.Voertuigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class NummerplaatDTO
    {
        public Guid Id { get; set; }
        public string Beschrijving { get; set; } = string.Empty;
        public bool IsActief { get; set; }
        public DateTime Datum { get; set; }
    }
}
