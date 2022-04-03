using CatchException.Tagging.Tagging;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace CatchException.Tagging;

public class TaggingDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly TestData _testData;
    protected ITagRepository _tagRepository;

    public TaggingDataSeedContributor(
        IGuidGenerator guidGenerator, ICurrentTenant currentTenant, ITagRepository tagRepository, TestData testData)
    {
        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _tagRepository = tagRepository;
        _testData = testData;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
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
    }
}
