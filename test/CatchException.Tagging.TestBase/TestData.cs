using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CatchException.Tagging
{
    public class TestData : ISingletonDependency
    {

        public string CurrentUserEmail { get; set; } = "377749229@qq.com";
        public Guid CurrentUserId { get; set; } = Guid.NewGuid();
        public string TestUserName { get; set; } = "MrChujiu";



        public string TestTagName { get; set; } = "ABP";
        public string TestTagDescription { get; set; } = "ABP.io";


        public string Tag1Name { get; set; } = "DDD";
        public string Tag2Name { get; set; } = "Test";

    }
}
