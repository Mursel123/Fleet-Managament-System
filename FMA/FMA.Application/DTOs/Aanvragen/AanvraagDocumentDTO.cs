using FMA.Domain.Enums;

namespace FMA.Application.DTOs.Aanvragen
{
    public class AanvraagDocumentDTO
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public BestandType BestandType { get; set; }
    }
}