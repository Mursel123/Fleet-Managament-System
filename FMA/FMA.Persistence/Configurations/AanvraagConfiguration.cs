using FMA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Persistence.Configurations
{
    public class AanvraagConfiguration : IEntityTypeConfiguration<Aanvraag>
    {
        public void Configure(EntityTypeBuilder<Aanvraag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Herstelling).WithOne(x => x.Aanvraag);
            builder.HasOne(x => x.Onderhoud).WithOne(x => x.Aanvraag);
            builder.HasOne(x => x.Voertuig).WithMany(x => x.Aanvragen);
            builder.HasOne(x => x.Chauffeur).WithMany(x => x.Aanvragen).IsRequired();
            builder.Property(x => x.StatusType).IsRequired();
            builder.Property(x => x.AanvraagType).IsRequired();
            builder.Property(x => x.DatumAanvraag).IsRequired();
            builder.Property(x => x.BeginPeriode).IsRequired();
            builder.Property(x => x.EindPeriode).IsRequired();
        }
    }
}
