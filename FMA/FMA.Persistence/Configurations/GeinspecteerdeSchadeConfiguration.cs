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
    public  class GeinspecteerdeSchadeConfiguration : IEntityTypeConfiguration<GeinspecteerdeSchade>
    {
        public void Configure(EntityTypeBuilder<GeinspecteerdeSchade> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Inspectieverslag).WithMany(x => x.GeinspecteerdeSchades).IsRequired();
            builder.HasOne(x => x.HerstellingType).WithMany(x => x.GeinspecteerdeSchades);
            builder.HasOne(x => x.GemeldeSchade).WithMany(x => x.GeinspecteerdeSchades);
            builder.Property(x => x.Onderdeel).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Schade).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Kostprijs).IsRequired();
        }
    }
}
