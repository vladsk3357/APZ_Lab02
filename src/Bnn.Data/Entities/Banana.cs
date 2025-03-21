namespace Bnn.Data.Entities;

public class Banana : BaseEntity
{
    public required string Name { get; set; }
    
    public required decimal Weight { get; set; }
}