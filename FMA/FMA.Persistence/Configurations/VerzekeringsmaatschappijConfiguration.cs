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
    public class VerzekeringsmaatschappijConfiguration : IEntityTypeConfiguration<Verzekeringsmaatschappij>
    {
        public void Configure(EntityTypeBuilder<Verzekeringsmaatschappij> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Referentienummer).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.Herstellingen).WithOne(x => x.Verzekeringsmaatschappij);
            builder.OwnsOne(x => x.Adres);
        }
    }
}
