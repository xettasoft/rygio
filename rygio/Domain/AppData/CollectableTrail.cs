using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class CollectableTrail : BaseEntity
    {
        public int? CollectableId { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
    }
}
