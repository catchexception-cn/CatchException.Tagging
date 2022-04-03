using CatchException.Tagging.Tagging;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace CatchException.Tagging.EntityFrameworkCore;

public static class TaggingDbContextModelCreatingExtensions
{
    public static void ConfigureTagging(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(TaggingDbProperties.DbTablePrefix + "Questions", TaggingDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<Tag>(b =>
        {
            b.ToTable(TaggingDbProperties.DbTablePrefix + "Tags", TaggingDbProperties.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Name).IsRequired().HasMaxLength(TagConsts.MaxNameLength).HasColumnName(nameof(Tag.Name));
            b.Property(x => x.Description).HasMaxLength(TagConsts.MaxDescriptionLength).HasColumnName(nameof(Tag.Description));
            b.Property(x => x.UsageCount).HasColumnName(nameof(Tag.UsageCount));

            b.ApplyObjectExtensionMappings();
        });
    }
}
