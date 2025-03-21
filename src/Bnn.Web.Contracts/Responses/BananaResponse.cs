namespace Bnn.Web.Contracts.Responses;

public class BananaResponse
{
    public required int Id { get; init; }
    
    public required string Name { get; init; }
    
    public required decimal Weight { get; init; }
}