using FMA.Domain.Entities;

namespace FMA.Contracts.Persistence
{
    public interface IVoertuigRepository
    {
        Task<List<T>> ReadVoertuigenSelectListAsync<T>(CancellationToken ct) where T : class, IVoertuigSelectList;
    }
}
