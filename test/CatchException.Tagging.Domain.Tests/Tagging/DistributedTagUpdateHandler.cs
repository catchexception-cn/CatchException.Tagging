using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Testing.Utils;

namespace CatchException.Tagging.Tagging;

public class DistributedTagUpdateHandler : IDistributedEventHandler<EntityUpdatedEto<TagEto>>, ITransientDependency
{
    private readonly ITestCounter _testCounter;

    public DistributedTagUpdateHandler(ITestCounter testCounter)
    {
        _testCounter = testCounter;
    }

    public Task HandleEventAsync(EntityUpdatedEto<TagEto> eventData)
    {
        _testCounter.Increment("EntityUpdatedEto<TagEto>");

        return Task.CompletedTask;
    }
}