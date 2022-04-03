using System;

using Volo.Abp.Domain.Entities;

namespace CatchException.Tagging.Tagging;

public interface ITagData : IAggregateRoot<Guid>
{
    string Name { get; }

    string Description { get; }
}