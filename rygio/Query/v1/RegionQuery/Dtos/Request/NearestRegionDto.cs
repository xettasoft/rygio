using rygio.Helper.pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Query.v1.RegionQuery.Dtos.Request
{
    public class NearestRegionDto:QueryStringParameters
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
