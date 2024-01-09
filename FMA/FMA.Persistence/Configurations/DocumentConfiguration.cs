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
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Herstelling).WithMany(x => x.Documenten);
            builder.HasOne(x => x.Onderhoud).WithOne(x => x.Document).HasForeignKey<Onderhoud>("DocumentId");
            builder.HasOne(x => x.Herstelling).WithMany(x => x.Documenten);
            builder.HasOne(x => x.GemeldeSchade).WithMany(x => x.Fotos);
            builder.Property(x => x.FileData).IsRequired();
            builder.Property(x => x.BestandType).IsRequired();
        }
    }
}
