using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.Aanvragen
{
    public class AanvraagOnderhoudDTO
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public string UitgevoerdeWerken { get; set; } = string.Empty;
        public virtual AanvraagDocumentDTO Document { get; set; }
    }
}
