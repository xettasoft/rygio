using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class Reply : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
        public int? UserId { get; set; }
        public int? CommentId { get; set; }
    }
}
