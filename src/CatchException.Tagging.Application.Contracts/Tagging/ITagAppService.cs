using CatchException.Tagging.Tagging.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace CatchException.Tagging.Tagging
{
    public interface ITagAppService : IApplicationService
    {

        Task<List<TagDto>> GetAsync(GetTagsInput input);

        Task<TagDto> CreateAsync(CreateTagDto input);

    }
}
