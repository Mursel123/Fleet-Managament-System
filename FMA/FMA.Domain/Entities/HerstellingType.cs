namespace FMA.Domain.Entities
{
    public class HerstellingType : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        public virtual List<GeinspecteerdeSchade> GeinspecteerdeSchades { get; init; }
    }
}