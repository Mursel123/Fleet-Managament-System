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
    public  class TankkaartConfiguration : IEntityTypeConfiguration<Tankkaart>
    {
        public void Configure(EntityTypeBuilder<Tankkaart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Chauffeurs).WithOne(x => x.Tankkaart);
            builder.HasMany(x => x.Services).WithMany(x => x.Tankkaarten);
            builder.HasIndex(x => x.KaartNummer).IsUnique();
            builder.Property(x => x.KaartNummer).HasMaxLength(50).IsRequired();
            builder.Property(x => x.GeldigheidsDatum).IsRequired();
            builder.Property(x => x.Pincode).HasMaxLength(50);
        }
    }
}
