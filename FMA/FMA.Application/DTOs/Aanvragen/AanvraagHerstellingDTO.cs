using FMA.Application.DTOs.SubDTOS;
using FMA.Domain.Entities;

namespace FMA.Application.DTOs.Aanvragen
{
    public class AanvraagHerstellingDTO
    {
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public virtual VerzekeringsmaatschappijDTO Verzekeringsmaatschappij { get; set; }
        public virtual AanvraagGemeldeSchadeDTO? GemeldeSchade { get; set; }
        public virtual List<AanvraagDocumentDTO> Documenten { get; init; }
    }
}
