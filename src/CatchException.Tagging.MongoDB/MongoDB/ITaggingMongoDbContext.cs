using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CatchException.Tagging.MongoDB;

[ConnectionStringName(TaggingDbProperties.ConnectionStringName)]
public interface ITaggingMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
