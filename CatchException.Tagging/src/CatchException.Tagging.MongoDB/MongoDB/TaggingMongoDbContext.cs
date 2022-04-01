using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace CatchException.Tagging.MongoDB;

[ConnectionStringName(TaggingDbProperties.ConnectionStringName)]
public class TaggingMongoDbContext : AbpMongoDbContext, ITaggingMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureTagging();
    }
}
