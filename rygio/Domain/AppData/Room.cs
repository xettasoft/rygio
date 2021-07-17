using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Room:BaseEntity
    {
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string Photo { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Connection { get; set; }
        public int? RegionId { get; set; }
        public bool IsPrivate { get; set; } = true;
        public bool PostAllowable { get; set; } = true;
        public IEnumerable<RoomMember> RoomMembers { get; set; }
    }
}
