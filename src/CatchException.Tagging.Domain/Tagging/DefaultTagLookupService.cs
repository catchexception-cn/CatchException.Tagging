using JetBrains.Annotations;

using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace CatchException.Tagging.Tagging;

public class DefaultTagLookupService : TagLookupService<Tag, ITagRepository>
{
    private readonly IGuidGenerator _guidGenerator;

    public DefaultTagLookupService(
        ITagRepository tagRepository,
        IUnitOfWorkManager unitOfWorkManager,
        IGuidGenerator guidGenerator) : base(tagRepository, unitOfWorkManager)
    {
        _guidGenerator = guidGenerator;
    }

    protected override Tag CreateTag(ITagData externalTag)
    {
        return new Tag(
            _guidGenerator.Create(),
            externalTag.Name,
            description: externalTag.Description);
    }
}