using FMA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<P?> GetByIdAsync<P>(Guid id, CancellationToken ct) where P : class;
        Task<List<R>> ListAllAsync<R>(CancellationToken ct) where R : class;
        Task AddAsync(T entity, CancellationToken ct);
        Task UpdateAsync(T entity, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}
