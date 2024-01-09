using FMA.Contracts.Persistence;

namespace FMA.Application.DTOs.Voertuigen
{
    public class VoertuigSelectListDTO : IVoertuigSelectList
    {
        public Guid Id { get; set; }
        public string Chassisnummer { get; set; }
    }
}
