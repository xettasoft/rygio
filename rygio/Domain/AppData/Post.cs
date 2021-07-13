using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Post : BaseEntity
    {

        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
       // [Column(TypeName = "bigint")]
        public int? RegionId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string MediaUrl { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Reference { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
