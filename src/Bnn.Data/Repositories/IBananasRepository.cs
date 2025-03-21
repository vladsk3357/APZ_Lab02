using Bnn.Data.Entities;

namespace Bnn.Data.Repositories;

public interface IBananasRepository
{
    Task<IEnumerable<Banana>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Banana?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    
    Task<int> CreateAsync(Banana banana, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Banana banana, CancellationToken cancellationToken = default);

    Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}