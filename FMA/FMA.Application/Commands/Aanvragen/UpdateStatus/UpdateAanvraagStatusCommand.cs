using FMA.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Aanvragen.UpdateStatus
{
    public class UpdateAanvraagStatusCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public StatusType StatusType { get; set; }
    }
}
