using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class Post : BaseEntity
    {

        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
        public int? UserId { get; set; }
        public int? RegionId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string MediaUrl { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Reference { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
