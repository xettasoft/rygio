using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class ExperienceMembers : BaseEntity
    {
        public int? ExperienceId { get; set; }
        public int? UserId { get; set; }
    }
}
