using FMA.Application.DTOs.Chauffeurs;

namespace FMA.Application.DTOs.SubDTOS
{
    public class GemeldeSchadeDTO
    {
        public Guid Id { get; set; }
        public DateTime DatumMelding { get; set; }
        public DateTime DatumSchade { get; set; }
        public string Schade { get; set; } = string.Empty;
        public virtual ChauffeurVoertuigDTO Voertuig { get; set; }
        public virtual List<DocumentDTO> Fotos { get; init; }

    }
}
