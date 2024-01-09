namespace FMA.Domain.Entities
{
    public class Verzekeringsmaatschappij : BaseEntity
    {
        public string Referentienummer { get; set; } = string.Empty;
        public virtual Adres? Adres { get; set; }
        public virtual Gemeente? Gemeente { get; init; }
        public virtual List<Herstelling> Herstellingen { get; init; }
    }
}