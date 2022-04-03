using Microsoft.Extensions.Options;

using Shouldly;

using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Testing.Utils;
using Volo.Abp.Uow;

using Xunit;
// ReSharper disable VirtualMemberCallInConstructor

namespace CatchException.Tagging.Tagging;

public class Distributed_Tag_Change_Event_Tests : TaggingDomainTestBase
{
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    private readonly ITestCounter _testCounter;
    private readonly ITagRepository _tagRepository;

    public Distributed_Tag_Change_Event_Tests()
    {
        _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        _testCounter = GetRequiredService<ITestCounter>();
        _tagRepository = GetRequiredService<ITagRepository>();
    }

    [Fact]
    public void Should_Register_Handler()
    {
        GetRequiredService<IOptions<AbpDistributedEntityEventOptions>>()
            .Value
            .EtoMappings
            .ShouldContain(m => m.Key == typeof(Tag) &&
                                m.Value.EtoType == typeof(TagEto));

        GetRequiredService<IOptions<AbpDistributedEventBusOptions>>()
            .Value
            .Handlers
            .ShouldContain(h => h == typeof(DistributedTagUpdateHandler));
    }

    [Fact]
    public async Task Should_Trigger_Distributed_EntityUpdated_Event()
    {
        using (var uow = _unitOfWorkManager.Begin())
        {
            var user = await _tagRepository.FirstOrDefaultAsync();
            user.SetName("Test1");

            _testCounter.GetValue("EntityUpdatedEto<TagEto>").ShouldBe(0);
            await uow.CompleteAsync();
        }

        _testCounter.GetValue("EntityUpdatedEto<TagEto>").ShouldBe(1);
    }
}