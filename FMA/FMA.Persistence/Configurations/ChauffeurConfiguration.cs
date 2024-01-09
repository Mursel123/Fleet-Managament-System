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
    public  class ChauffeurConfiguration : IEntityTypeConfiguration<Chauffeur>
    {
        public void Configure(EntityTypeBuilder<Chauffeur> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            
            builder.HasOne(x => x.Tankkaart).WithMany(x => x.Chauffeurs);
            builder.OwnsOne(x => x.Adres);

            builder.HasMany(x => x.Aanvragen).WithOne(x => x.Chauffeur);
            builder.HasMany(x => x.Inspectieverslagen).WithOne(x => x.Chauffeur);
            builder.HasMany(x => x.GemeldeSchades).WithOne(x => x.Chauffeur);

            builder.Property(x => x.Naam).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Voornaam).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Geboortedatum).IsRequired();

            
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();

            builder.Property(x => x.Geslacht).IsRequired();

            builder.HasIndex(x => x.Rijksregisternummer).IsUnique();
            builder.Property(x => x.Rijksregisternummer).HasMaxLength(15).IsFixedLength().IsRequired();

        }
    }
}
