using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class PostMember
    {
        //[Column(TypeName = "bigint")]
        public int? PostId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
    }
}
