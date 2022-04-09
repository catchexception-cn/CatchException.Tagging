using AutoMapper;

using CatchException.Tagging.Blazor.Models;
using CatchException.Tagging.Tagging.Dtos;

namespace CatchException.Tagging.Blazor;

public class TaggingBlazorAutoMapperProfile : Profile
{
    public TaggingBlazorAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<TagDto, TagWhitelistModel>()
            .ForMember(des => des.Value,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(des => des.Code,
                opt => opt.MapFrom(src => src.Id.ToString()));
    }
}
