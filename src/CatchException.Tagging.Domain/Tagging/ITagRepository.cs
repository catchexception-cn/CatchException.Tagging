using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace CatchException.Tagging.Tagging
{
    public interface ITagRepository : ITagRepository<Tag>
    {

    }

    public interface ITagRepository<TTag> : IRepository<TTag, Guid>
        where TTag : class, ITag
    {
        Task<List<TTag>> GetListAsync(string name, CancellationToken cancellationToken = default);
    }
}
