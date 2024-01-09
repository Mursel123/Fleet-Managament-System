using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Contracts.Persistence
{
    public interface IVoertuigSelectList
    {
         Guid Id { get; set; }
         string Chassisnummer { get; set; }
    }
}
