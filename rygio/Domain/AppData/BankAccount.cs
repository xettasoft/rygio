using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class BankAccount : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string BankName { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string BankCode { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string AccountName { get; set; }
        public int? UserId { get; set; }
    }
}
