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
    public  class VoertuigConfiguration : IEntityTypeConfiguration<Voertuig>
    {
        public void Configure(EntityTypeBuilder<Voertuig> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Chassisnummer).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.Nummerplaten).WithMany(x => x.Voertuigen);
            builder.HasMany(x => x.Kilometerstanden).WithOne(x => x.Voertuig);
            builder.HasMany(x => x.Inspectieverslagen).WithOne(x => x.Voertuig);
            builder.HasMany(x => x.Aanvragen).WithOne(x => x.Voertuig);
            builder.HasMany(x => x.GemeldeSchades).WithOne(x => x.Voertuig);
            builder.HasMany(x => x.Herstellingen).WithOne(x => x.Voertuig);
            builder.HasMany(x => x.Onderhouden).WithOne(x => x.Voertuig);
        }
    }
}
