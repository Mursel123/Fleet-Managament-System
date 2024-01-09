using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Tankkaarten.UnblockTankkaart
{
    public class UnblockTankkaartCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
