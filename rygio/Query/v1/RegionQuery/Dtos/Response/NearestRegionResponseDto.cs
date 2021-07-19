using rygio.Domain.AppData;
using rygio.Query.v1.BaseDtos;
using rygio.Query.v1.RegionQuery.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Query.v1.RegionQuery.Dtos.Response
{
    public class NearestRegionResponseDto:PaginationDto
    {
        public List<RegionQueryDto> Data { get; set; }
    }
}
