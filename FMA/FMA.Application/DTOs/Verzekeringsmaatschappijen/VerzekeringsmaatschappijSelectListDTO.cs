using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Verzekeringsmaatschappijen
{
    public class VerzekeringsmaatschappijSelectListDTO
    {
        public Guid Id { get; set; }
        public string Referentienummer { get; set; } = string.Empty;
    }
}
