using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Query.v1.RegionQuery.Dtos.Request
{
    public class RegionQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Region";
        public string Decription { get; set; }
        public string Photo { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool IsLocked { get; set; } = false;
        public bool CanMemberPost { get; set; } = true;
        public string ConnectionId { get; set; }
        public string Reference { get; set; }
        //public Point Location { get; set; }
        //public Geometry Border { get; set; }
        public double Radius { get; set; }

    }
}
