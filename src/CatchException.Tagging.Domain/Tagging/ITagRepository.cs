using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace CatchException.Tagging.Tagging
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<List<TTag>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    }
}
