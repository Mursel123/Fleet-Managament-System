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
    public class NummerplaatConfiguration : IEntityTypeConfiguration<Nummerplaat>
    {
        public void Configure(EntityTypeBuilder<Nummerplaat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Beschrijving).HasMaxLength(9).IsRequired();
            builder.HasMany(x => x.Voertuigen).WithMany(x => x.Nummerplaten);
            builder.Property(x => x.Datum).IsRequired();
            builder.Property(x => x.IsActief).IsRequired();


        }
    }
}
