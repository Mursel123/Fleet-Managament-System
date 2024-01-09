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
    public  class GemeldeSchadeConfiguration : IEntityTypeConfiguration<GemeldeSchade>
    {
        public void Configure(EntityTypeBuilder<GemeldeSchade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Voertuig).WithMany(x => x.GemeldeSchades).IsRequired();
            builder.HasOne(x => x.Chauffeur).WithMany(x => x.GemeldeSchades).IsRequired();
            builder.HasMany(x => x.GeinspecteerdeSchades).WithOne(x => x.GemeldeSchade);
            builder.HasMany(x => x.Herstellingen).WithOne(x => x.GemeldeSchade);
            builder.HasMany(x => x.Fotos).WithOne(x => x.GemeldeSchade);
            builder.Property(x => x.DatumMelding).IsRequired();
            builder.Property(x => x.Schade).HasMaxLength(255);

        }
    }
}
