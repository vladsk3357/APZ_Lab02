using Bnn.Data.Entities;
using LazyCache;

namespace Bnn.Data.Repositories.Caching;

internal class BananasCachedRepository(IBananasRepository bananasRepository, IAppCache cache) : IBananasRepository
{
    public async Task<IEnumerable<Banana>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await cache.GetOrAddAsync(BananaCacheKeys.All,
            () => bananasRepository.GetAllAsync(cancellationToken));
    }

    public async Task<Banana?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await cache.GetOrAddAsync(BananaCacheKeys.ById(id),
            () => bananasRepository.GetByIdAsync(id, cancellationToken));
    }

    public Task<int> CreateAsync(Banana banana, CancellationToken cancellationToken = default)
    {
        return bananasRepository.CreateAsync(banana, cancellationToken);
    }

    public async Task<bool> UpdateAsync(Banana banana, CancellationToken cancellationToken = default)
    {
        var result = await bananasRepository.UpdateAsync(banana, cancellationToken);
        if (result)
        {
            cache.Remove(BananaCacheKeys.ById(banana.Id));
        }
        
        return result;
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await bananasRepository.DeleteByIdAsync(id, cancellationToken);
        if (result)
        {
            cache.Remove(BananaCacheKeys.ById(id));
        }
        
        return result;
    }
}