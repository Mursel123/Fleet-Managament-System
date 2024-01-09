using FMA.Domain.Entities;
using FMA.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.Commands.Facturen.Create
{
    public class CreateDocumentCommand : IRequest<Guid>
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public BestandType BestandType { get; set; }
        public Guid? HerstellingId { get; set; }

    }
}
