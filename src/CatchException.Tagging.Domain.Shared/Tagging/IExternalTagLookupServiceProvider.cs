namespace CatchException.Tagging.Tagging;

public interface IExternalTagLookupServiceProvider
{
    Task<ITagData?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    
    Task<List<ITagData>> SearchAsync(
        string? filter = null,
        int maxResultCount = int.MaxValue,
        CancellationToken cancellationToken = default);
}