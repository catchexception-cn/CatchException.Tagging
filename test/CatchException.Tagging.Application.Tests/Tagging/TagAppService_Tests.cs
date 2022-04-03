using CatchException.Tagging.Tagging.Dtos;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Xunit;

namespace CatchException.Tagging.Tagging
{
    public class TagAppService_Tests : TaggingApplicationTestBase
    {

        private readonly ITagAppService _tagAppService;
        private readonly TestData _testData;
        private ICurrentUser _currentUser;

        public TagAppService_Tests()
        {
            _tagAppService = GetRequiredService<ITagAppService>();
            _testData = GetRequiredService<TestData>();
            _currentUser = GetRequiredService<ICurrentUser>();
        }

        protected override void AfterAddApplication(IServiceCollection services)
        {
            _currentUser = Substitute.For<ICurrentUser>();
            services.AddSingleton(_currentUser);
        }


        [Fact]
        public async Task Should_Create_Tag() {


            _currentUser.Id.Returns(_testData.CurrentUserId);
            _currentUser.Email.Returns(_testData.CurrentUserEmail);
            _currentUser.Name.Returns(_testData.TestUserName);


            var newTagDto = await _tagAppService.CreateAsync(new CreateTagDto()
            {
                Name = _testData.TestTagName,
                Description = _testData.TestTagDescription
            });

            newTagDto.Id.ShouldNotBe(Guid.Empty);

            var myTag = await _tagAppService.GetAsync(new GetTagsInput() { ResultCount = 5, Name = newTagDto.Name });
            myTag.ShouldNotBeNull();
        }



    }
}
