using System;
using System.Collections.Generic;
using System.Text;

namespace CatchException.Tagging.Tagging.Dtos
{
    public class GetTagsInput
    {
        public int ResultCount { get; set; } = 10;

        public string Name { get; set; }

    }
}
