using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Tankkaarten.BlockTankkaart
{
    public class BlockTankkaartCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
