using Volo.Abp;
using Volo.Abp.MongoDB;

namespace CatchException.Tagging.MongoDB;

public static class TaggingMongoDbContextExtensions
{
    public static void ConfigureTagging(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
