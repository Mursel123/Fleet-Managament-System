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
    public class HerstellingConfiguration : IEntityTypeConfiguration<Herstelling>
    {

        public void Configure(EntityTypeBuilder<Herstelling> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Aanvraag).WithOne(x => x.Herstelling).HasForeignKey<Aanvraag>("HerstellingId");
            builder.HasOne(x => x.Voertuig).WithMany(x => x.Herstellingen).IsRequired();
            builder.HasOne(x => x.Verzekeringsmaatschappij).WithMany(x => x.Herstellingen).IsRequired();
            builder.HasOne(x => x.GemeldeSchade).WithMany(x => x.Herstellingen);
            builder.HasMany(x => x.Documenten).WithOne(x => x.Herstelling);
            builder.Property(x => x.DatumUitvoering).IsRequired();

        }
    }
}
