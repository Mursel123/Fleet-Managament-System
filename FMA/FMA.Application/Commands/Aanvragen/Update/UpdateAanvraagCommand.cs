using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Aanvragen.Update
{
    public class UpdateAanvraagCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid? OnderhoudId { get; set; }
        public Guid? HerstellingId { get; set; }
    }
}
