using Bnn.Data.Entities;
using Bnn.Data.Repositories;
using Bnn.Services.Bananas;
using FakeItEasy;

namespace Bnn.Services.Tests.Bananas;

public class BananasServiceTests
{
    private readonly IBananasRepository _bananasRepository;
    private readonly BananasService _bananasService;

    public BananasServiceTests()
    {
        _bananasRepository = A.Fake<IBananasRepository>();
        _bananasService = new BananasService(_bananasRepository);
    }
    
    [Fact]
    public async Task GetBananaById_ValidId_ShouldReturnBanana()
    {
        const int id = 1;
        var banana = new Banana
        {
            Id = id,
            Name = "banana",
            Weight = 1,
        };
        var bananasRepositoryGetByIdAsyncCall =
            A.CallTo(() => _bananasRepository.GetByIdAsync(id, A<CancellationToken>._));
        bananasRepositoryGetByIdAsyncCall.Returns(banana);

        var result = await _bananasService.GetBananaById(id);
        
        Assert.NotNull(result);
        Assert.Equal(banana, result.Value);
        bananasRepositoryGetByIdAsyncCall.MustHaveHappenedOnceExactly();
    }
}