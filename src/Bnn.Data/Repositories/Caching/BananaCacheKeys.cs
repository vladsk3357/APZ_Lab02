namespace Bnn.Data.Repositories.Caching;

public static class BananaCacheKeys
{
    public const string All = "Bananas.All";
    
    public static string ById(int id) => $"Bananas.Id:{id}";
}