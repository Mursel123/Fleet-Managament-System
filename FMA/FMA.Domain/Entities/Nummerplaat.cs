namespace FMA.Domain.Entities
{
    public class Nummerplaat : BaseEntity
    {
        public string Beschrijving { get; set; } = string.Empty;
        public bool IsActief { get; set; }
        public DateTime Datum { get; set; }
        public virtual List<Voertuig> Voertuigen { get; init; }
    }
}