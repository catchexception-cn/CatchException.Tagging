namespace CatchException.Tagging.Tagging;

public interface ITagLookupService<TTag>
{
    Task<TTag?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );
}