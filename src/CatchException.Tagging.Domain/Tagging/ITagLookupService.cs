namespace CatchException.Tagging.Tagging;

public interface ITagLookupService<TTag>
{
    Task<TTag?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<List<ITagData>> SearchAsync(
        string? filter = null,
        int maxResultCount = int.MaxValue,
        CancellationToken cancellationToken = default);
}