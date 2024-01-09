using FMA.Contracts.Persistence;
using FMA.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;

namespace FMA.Persistence
{
    public class FMADbContext : IdentityDbContext, IWriteDbContext , IReadDbContext
    {
        public FMADbContext(DbContextOptions<FMADbContext> options) : base(options)
        {
            
        }

        
        public DbSet<Document>? Document { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Tankkaart>? Tankkaart { get; set; }
        public DbSet<Chauffeur>? Chauffeur { get; set; }
        public DbSet<Gemeente>? Gemeente { get; set; }
        public DbSet<Voertuig>? Voertuig { get; set; }
        public DbSet<Herstelling>? Herstelling { get; set; }
        public DbSet<HerstellingType>? HerstellingType { get; set; }
        public DbSet<GemeldeSchade>? GemeldeSchade { get; set; }
        public DbSet<GeinspecteerdeSchade>? GeinspecteerdeSchade { get; set; }
        public DbSet<Verzekeringsmaatschappij>? Verzekeringsmaatschappij { get; set; }
        public DbSet<Inspectieverslag>? Inspectieverslag { get; set; }
        public DbSet<Kilometerstand>? Kilometerstand { get; set; }
        public DbSet<Aanvraag>? Aanvraag { get; set; }
        public DbSet<Onderhoud>? Onderhoud { get; set; }
        public DbSet<Garage>? Garage { get; set; }
        public DbSet<Nummerplaat>? Nummerplaat { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Configurations.AanvraagConfiguration).Assembly);
            base.OnModelCreating(builder);

        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking();
        }

    }
}
