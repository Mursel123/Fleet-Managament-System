using FMA.Application.DTOs.Tankkaarten;
using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;

namespace FMA.Application.Commands.Tankkaarten.CreateTankkaart
{
    public class CreateTankkaartCommand : IRequest<Guid>
    {
        public string KaartNummer { get; set; } = string.Empty;
        public DateTime GeldigheidsDatum { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public bool IsGeblokkeerd { get; set; } = false;

        public BrandstofType? BrandstofType { get; set; }
        public AuthenticatieType? AuthenticatieType { get; set; }

        public List<ServiceVm> Services { get; set; }
    }
}
