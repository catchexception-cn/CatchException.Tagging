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
        Task<List<TagDto>> GetListAsync(GetTagListInput input, CancellationToken cancellationToken);

        Task<TagDto> CreateAsync(CreateTagDto input);
    }
}
