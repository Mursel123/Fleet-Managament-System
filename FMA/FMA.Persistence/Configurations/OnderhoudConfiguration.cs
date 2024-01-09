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
    public class OnderhoudConfiguration : IEntityTypeConfiguration<Onderhoud>
    {
        public void Configure(EntityTypeBuilder<Onderhoud> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Aanvraag).WithOne(x => x.Onderhoud).HasForeignKey<Aanvraag>("OnderhoudId");
            builder.HasOne(x => x.Voertuig).WithMany(x => x.Onderhouden).IsRequired();
            builder.HasOne(x => x.Garage).WithMany(x => x.Onderhouden);
            builder.HasOne(x => x.Document).WithOne(x => x.Onderhoud);
            builder.Property(x => x.DatumUitvoering).IsRequired();

        }
    }
}
