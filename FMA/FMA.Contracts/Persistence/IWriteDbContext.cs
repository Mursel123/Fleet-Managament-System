using Microsoft.EntityFrameworkCore;

namespace FMA.Contracts.Persistence
{
    public interface IWriteDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
