using AutoMapper;
using CatchException.Tagging.Tagging;
using CatchException.Tagging.Tagging.Dtos;

namespace CatchException.Tagging;

public class TaggingApplicationAutoMapperProfile : Profile
{
    public TaggingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Tag, TagDto>();
    }
}
