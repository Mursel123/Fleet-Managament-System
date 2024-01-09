using FMA.Application.DTOs.Voertuigen;
using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Application.DTOs.SubDTOS
{
    public class HerstellingDTO
    {
        public Guid Id { get; set; }
        public DateTime DatumUitvoering { get; set; }
        public decimal Kostprijs { get; set; }
        public virtual VoertuigDTO Voertuig { get; set; }
        public virtual VerzekeringsmaatschappijDTO Verzekeringsmaatschappij { get; set; }
        public virtual GemeldeSchadeDTO? GemeldeSchade { get; set; }
        public virtual List<DocumentDTO> Documenten { get; init; }
    }
}
