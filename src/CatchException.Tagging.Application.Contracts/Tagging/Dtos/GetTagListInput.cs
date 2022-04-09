using System;
using System.Collections.Generic;
using System.Text;

using Volo.Abp.Application.Dtos;

namespace CatchException.Tagging.Tagging.Dtos
{
    public class GetTagListInput : LimitedResultRequestDto
    {
        public string Name { get; set; } = default!;
    }
}
