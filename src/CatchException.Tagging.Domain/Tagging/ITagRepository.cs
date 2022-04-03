using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CatchException.Tagging.Tagging
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<List<Tag>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    }
}
