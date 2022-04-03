using CatchException.Tagging.Tagging;
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
    private readonly TestData _testData;
    protected ITagRepository _tagRepository;

    public TaggingDataSeedContributor(
        IGuidGenerator guidGenerator, ICurrentTenant currentTenant, ITagRepository tagRepository, TestData testData)
        IGuidGenerator guidGenerator, ICurrentTenant currentTenant, ITagRepository tagRepository, IUnitOfWorkManager unitOfWorkManager)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _tagRepository = tagRepository;
        _unitOfWorkManager = unitOfWorkManager;
        _tagRepository = tagRepository;
        _testData = testData;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using var uow = _unitOfWorkManager.Begin();
        /* Instead of returning the Task.CompletedTask, you can insert your test data
         * at this point!
         */
        using (_currentTenant.Change(context?.TenantId))
        {
            await SeedTestTagsAsync();
        }
    }

    private async Task SeedTestTagsAsync()
    {
        await _tagRepository.InsertAsync(new Tag(_guidGenerator.Create(), _testData.Tag1Name,0,""));
            await _tagRepository.InsertAsync(new Tag(Guid.NewGuid(), "Test"));
            await uow.CompleteAsync();
        }
    }
}
