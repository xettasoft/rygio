using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class RegionMember : BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int? RegionId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
        public bool IsSuperAdmin { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool IsBlocked { get; set; } = false;
        public bool IsAvailable { get; set; } = false;
        public bool CanMint { get; set; }
        public bool CanRedeem { get; set; }
        public bool CanDelete { get; set; }
    }
}
