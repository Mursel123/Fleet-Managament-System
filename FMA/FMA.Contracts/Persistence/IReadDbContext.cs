namespace FMA.Contracts.Persistence
{
    public interface IReadDbContext
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

    }
}
