using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.GemeldeSchades
{
    public class GemeldeSchadeSelectListDTO
    {
        public Guid Id { get; set; }
        public DateTime DatumMelding { get; set; }
        public DateTime DatumSchade { get; set; }
        public string Schade { get; set; } = string.Empty;
    }
}
