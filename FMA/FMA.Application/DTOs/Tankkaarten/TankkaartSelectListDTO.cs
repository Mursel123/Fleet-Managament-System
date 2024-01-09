using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Tankkaarten
{
    public class TankkaartSelectListDTO
    {
        public Guid Id { get; set; }
        public string KaartNummer { get; set; } = string.Empty;
    }
}
