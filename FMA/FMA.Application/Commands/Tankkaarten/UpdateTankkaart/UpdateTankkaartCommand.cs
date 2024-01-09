using FMA.Application.DTOs.Tankkaarten;
using FMA.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Tankkaarten.UpdateTankkaart
{
    public class UpdateTankkaartCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime GeldigheidsDatum { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public AuthenticatieType? AuthenticatieType { get; set; }
        public BrandstofType? BrandstofType { get; set; }
    }
}
