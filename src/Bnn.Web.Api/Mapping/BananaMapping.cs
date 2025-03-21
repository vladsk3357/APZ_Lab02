using Bnn.Data.Entities;
using Bnn.Web.Contracts.Requests;
using Bnn.Web.Contracts.Responses;

namespace Bnn.Web.Api.Mapping;

internal static class BananaMapping
{
    public static Banana MapToEntity(this CreateBananaRequest createBananaRequest) => new()
    {
        Id = 0,
        Name = createBananaRequest.Name,
        Weight = createBananaRequest.Weight,
    };
    
    public static Banana MapToEntity(this UpdateBananaRequest addBananaRequest, int id) => new()
    {
        Id = id,
        Name = addBananaRequest.Name,
        Weight = addBananaRequest.Weight,
    };

    public static BananaResponse MapToResponse(this Banana entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Weight = entity.Weight,
    };
}