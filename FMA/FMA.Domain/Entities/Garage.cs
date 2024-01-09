using System.ComponentModel.DataAnnotations.Schema;

namespace FMA.Domain.Entities
{

    public class Garage : BaseEntity
    {
        public string Naam { get; set; } = string.Empty;
        public virtual Adres? Adres { get; set; }
        public virtual Gemeente? Gemeente { get; init; }
        public virtual List<Onderhoud> Onderhouden { get; init; }
    }
}