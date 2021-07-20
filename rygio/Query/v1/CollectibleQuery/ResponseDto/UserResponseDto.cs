using rygio.Query.v1.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Query.v1.CollectibleQuery.ResponseDto
{
    public class UserResponseDto : PaginationDto
    {
        public List<CollectibleDto> Data { get; set; }
    }
}
