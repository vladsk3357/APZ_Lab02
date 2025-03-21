using Bnn.Services.Common;

namespace Bnn.Services.Bananas;

public static class BananaErrors
{
    public static Error NotFound(int bananaId) => Error.NotFound(
        "Bananas.NotFound",
        $"The banana with the Id = '{bananaId}' was not found.");
}   