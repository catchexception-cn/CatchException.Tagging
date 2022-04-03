using System.Threading.Tasks;

using CatchException.Tagging.Tagging;

using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace CatchException.Tagging;

public class TaggingDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    private readonly ITagRepository _tagRepository;
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;

    public TaggingDataSeedContributor(
        IGuidGenerator guidGenerator, ICurrentTenant currentTenant, ITagRepository tagRepository, IUnitOfWorkManager unitOfWorkManager)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _tagRepository = tagRepository;
        _unitOfWorkManager = unitOfWorkManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using var uow = _unitOfWorkManager.Begin();
        using (_currentTenant.Change(context?.TenantId))
        {
            await _tagRepository.InsertAsync(new Tag(Guid.NewGuid(), "Test"));
            await uow.CompleteAsync();
        }
    }
}
