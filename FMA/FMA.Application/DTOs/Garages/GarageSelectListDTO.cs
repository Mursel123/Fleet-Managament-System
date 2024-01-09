using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Garages
{
    public class GarageSelectListDTO
    {
        public Guid Id { get; set; }
        public string Naam { get; set; } = string.Empty;
    }
}
