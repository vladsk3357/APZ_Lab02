using Bnn.Data.Entities;
using Bnn.Data.Repositories;
using Bnn.Services.Common;

namespace Bnn.Services.Bananas;

public class BananasService(IBananasRepository bananasRepository) : IBananasService
{
    public async Task<Result<Banana>> GetBananaById(int id, CancellationToken cancellationToken = default)
    {
        var banana = await bananasRepository.GetByIdAsync(id, cancellationToken);
        return banana is null ? Result.Failure<Banana>(BananaErrors.NotFound(id)) : Result.Success(banana);
    }

    public async Task<Result<IList<Banana>>> GetAllBananas(CancellationToken cancellationToken = default)
    {
        var bananas = await bananasRepository.GetAllAsync(cancellationToken);
        return bananas.ToList();
    }

    public async Task<Result> CreateBanana(Banana banana, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(banana);
        var id = await bananasRepository.CreateAsync(banana, cancellationToken);
        var inserted = await bananasRepository.GetByIdAsync(id, cancellationToken);
        return Result.Success(inserted);
    }

    public async Task<Result<Banana>> UpdateBanana(Banana banana, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(banana);
        var result = await bananasRepository.UpdateAsync(banana, cancellationToken);
        return result ? Result.Success(banana) : Result.Failure<Banana>(BananaErrors.NotFound(banana.Id));
    }

    public async Task<Result> DeleteBananaById(int id, CancellationToken cancellationToken = default)
    {
        var result = await bananasRepository.DeleteByIdAsync(id, cancellationToken);
        return result ? Result.Success() : Result.Failure(BananaErrors.NotFound(id));
    }
}