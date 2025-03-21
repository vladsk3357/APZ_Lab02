using Bnn.Data.Entities;
using Bnn.Services.Common;

namespace Bnn.Services.Bananas;

public interface IBananasService
{
    Task<Result<Banana>> GetBananaById(int id, CancellationToken cancellationToken = default);
    
    Task<Result<IList<Banana>>> GetAllBananas(CancellationToken cancellationToken = default);
    
    Task<Result> CreateBanana(Banana banana, CancellationToken cancellationToken = default);
    
    Task<Result<Banana>> UpdateBanana(Banana banana, CancellationToken cancellationToken = default);
    
    Task<Result> DeleteBananaById(int id, CancellationToken cancellationToken = default);
}