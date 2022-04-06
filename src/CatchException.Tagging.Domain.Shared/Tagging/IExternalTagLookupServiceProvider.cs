namespace CatchException.Tagging.Tagging;

public interface IExternalTagLookupServiceProvider
{
    Task<ITagData?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );
}