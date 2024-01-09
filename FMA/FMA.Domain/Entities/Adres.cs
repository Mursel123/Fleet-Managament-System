
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Domain.Entities
{
    public class Adres
    {
        public string Straat { get; set; } = string.Empty;
        public string Nummer { get; set; } = string.Empty;
        public string Bus { get; set; } = string.Empty;

    }
}
