
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class GemeenteDTO
    {
        public Guid Id { get; set; }
        public string Postcode { get; set; } = string.Empty;
        public string Stad { get; set; } = string.Empty;
    }
}
