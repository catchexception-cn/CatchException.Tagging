using AutoMapper;

using CatchException.Tagging.Tagging;

namespace CatchException.Tagging;

public class TaggingDomainMappingProfile : Profile
{
    public TaggingDomainMappingProfile()
    {
        CreateMap<Tag, TagEto>();
    }
}