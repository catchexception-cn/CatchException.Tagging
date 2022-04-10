using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CatchException.Tagging.Tagging;

public interface ITagLookupAppService : IApplicationService
{
    Task<TagData?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<List<TagData>> SearchAsync(
        string? filter = null,
        int maxResultCount = int.MaxValue,
        CancellationToken cancellationToken = default);
}