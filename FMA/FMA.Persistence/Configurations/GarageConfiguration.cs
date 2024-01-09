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
    public class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Naam).HasMaxLength(255).IsRequired();
            builder.HasMany(x => x.Onderhouden).WithOne(x => x.Garage);
            builder.OwnsOne(x => x.Adres);


        }
    }
}
