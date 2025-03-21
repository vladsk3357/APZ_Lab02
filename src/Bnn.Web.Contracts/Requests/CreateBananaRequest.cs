using System.ComponentModel.DataAnnotations;

namespace Bnn.Web.Contracts.Requests;

public class CreateBananaRequest
{
    [Required]
    public required string Name { get; init; }
    
    [Required]
    public required decimal Weight { get; init; }
}