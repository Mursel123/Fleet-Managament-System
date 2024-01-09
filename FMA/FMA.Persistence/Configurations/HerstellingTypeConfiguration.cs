using FMA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMA.Persistence.Configurations
{
    public class HerstellingTypeConfiguration : IEntityTypeConfiguration<HerstellingType>
    {
        public void Configure(EntityTypeBuilder<HerstellingType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.GeinspecteerdeSchades).WithOne(x => x.HerstellingType);

        }
    }
}
