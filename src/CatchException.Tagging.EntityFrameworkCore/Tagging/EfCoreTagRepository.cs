using CatchException.Tagging.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CatchException.Tagging.Tagging
{
    public class EfCoreTagRepository : EfCoreRepository<ITaggingDbContext, Tag, Guid>, ITagRepository
    {
        public EfCoreTagRepository(IDbContextProvider<ITaggingDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Tag>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).WhereIf(!name.IsNullOrEmpty(), x => x.Name.Contains(name)).ToListAsync(cancellationToken);
        }
    }
}
