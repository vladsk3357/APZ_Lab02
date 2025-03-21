namespace Bnn.Services.Common;

public sealed record ValidationError(ICollection<Error> Errors) 
    : Error("Validation.General",
        "One or more validation errors occurred",
        ErrorType.Validation)
{
    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}
