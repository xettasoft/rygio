using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class RoomMember:BaseEntity
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
