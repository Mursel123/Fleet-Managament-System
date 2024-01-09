using FMA.Domain.Entities;

namespace FMA.Application.DTOs.SubDTOS
{
    public class FactuurDTO
    {
        public Guid Id { get; set; }
        public string Beschrijving { get; set; } = string.Empty;
        public virtual OnderhoudDTO Onderhoud { get; set; }
    }
}