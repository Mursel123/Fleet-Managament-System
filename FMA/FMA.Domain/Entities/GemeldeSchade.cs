namespace FMA.Domain.Entities
{
    public class GemeldeSchade : BaseEntity
    {
        public DateTime DatumMelding { get; set; }
        public DateTime DatumSchade { get; set; }
        public string Schade { get; set; } = string.Empty;

        public virtual Chauffeur Chauffeur { get; set; }
        public virtual Voertuig Voertuig { get; set; }
        public virtual List<Document> Fotos { get; init; }
        public virtual List<GeinspecteerdeSchade> GeinspecteerdeSchades { get; init; }
        public virtual List<Herstelling> Herstellingen { get; init; }
    }
}