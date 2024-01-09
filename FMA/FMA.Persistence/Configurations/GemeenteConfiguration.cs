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
    public class GemeenteConfiguration : IEntityTypeConfiguration<Gemeente>
    {
        public void Configure(EntityTypeBuilder<Gemeente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Postcode).HasMaxLength(4).IsFixedLength().IsRequired();
            builder.Property(x => x.Stad).HasMaxLength(50).IsRequired();

        }
    }
}
