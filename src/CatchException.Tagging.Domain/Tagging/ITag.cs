using Volo.Abp.Domain.Entities;

namespace CatchException.Tagging.Tagging;

public interface ITag : IAggregateRoot<Guid>
{
    string Name { get; }

    string Description { get; }
}