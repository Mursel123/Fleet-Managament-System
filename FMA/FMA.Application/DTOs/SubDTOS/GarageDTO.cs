using FMA.Domain.Entities;

namespace FMA.Application.DTOs.SubDTOS
{
    public class GarageDTO
    {
        public Guid Id { get; set; }
        public string Naam { get; set; } = string.Empty;
    }
}