using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace CatchException.Tagging.Tagging
{
    public abstract  class TagRepositoryTests<TStartupModule> : TaggingTestBase<TStartupModule> where TStartupModule : IAbpModule
    {
        protected ITagRepository TagRepository { get; }
        protected TestData TestData  { get; }

    protected TagRepositoryTests()
        {
            TagRepository = GetRequiredService<ITagRepository>();
            TestData = GetRequiredService<TestData>();
        }

        [Fact]
        public async Task GetByNameAsync()
        {
            var tag = await TagRepository.GetByNameAsync(TestData.Tag1Name);
            tag.ShouldNotBeNull();
            tag[0].Name.ShouldBe(TestData.Tag1Name);
        }


    }
}
