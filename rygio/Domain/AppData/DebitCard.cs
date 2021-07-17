using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class DebitCard : BaseEntity
    {
        public int? UserId { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string CardNumber { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Expiry { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string CVV { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Authorization { get; set; }
    }
}
