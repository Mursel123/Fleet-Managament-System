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
    public  class KilometerstandConfiguration : IEntityTypeConfiguration<Kilometerstand>
    {
        public void Configure(EntityTypeBuilder<Kilometerstand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Voertuig).WithMany(x => x.Kilometerstanden).IsRequired();
            builder.Property(x => x.Datum).IsRequired();
            builder.Property(x => x.Stand).HasMaxLength(50).IsRequired();

        }
    }
}
