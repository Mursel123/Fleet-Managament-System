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
    public  class InspectieverslagConfiguration : IEntityTypeConfiguration<Inspectieverslag>
    {
        public void Configure(EntityTypeBuilder<Inspectieverslag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Voertuig).WithMany(x => x.Inspectieverslagen).IsRequired();
            builder.HasOne(x => x.Chauffeur).WithMany(x => x.Inspectieverslagen).IsRequired();
            builder.HasMany(x => x.GeinspecteerdeSchades).WithOne(x => x.Inspectieverslag);
            builder.Property(x => x.DatumUitvoering).IsRequired();
            builder.Property(x => x.ChauffeurAanwezig).IsRequired();
            builder.Property(x => x.Verslag).HasMaxLength(255);
        }
    }
}
