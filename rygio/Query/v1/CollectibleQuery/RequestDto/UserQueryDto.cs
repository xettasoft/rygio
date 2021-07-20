using rygio.Helper.pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Query.v1.CollectibleQuery.RequestDto
{
    public class UserQueryDto : QueryStringParameters
    {
        public bool IsTemplate { get; set; } = false;
    }
}
