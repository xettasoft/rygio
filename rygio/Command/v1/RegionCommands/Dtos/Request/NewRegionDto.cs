using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.RegionCommands.Dtos.Request
{
    public class NewRegionDto
    {
        public string Name { get; set; } = "Region";
        public string Decription { get; set; }
        public bool IsPrivate { get; set; } = false;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        //public List<RegionMemberDto> RegionMembers { get; set; } = new List<RegionMemberDto>();
    }
}
