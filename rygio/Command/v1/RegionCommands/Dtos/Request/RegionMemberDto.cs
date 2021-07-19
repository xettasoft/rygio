using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.RegionCommands.Dtos.Request
{
    public class RegionMemberDto
    {
        public int? RegionId { get; set; }
        public int? UserId { get; set; }
    }
}
