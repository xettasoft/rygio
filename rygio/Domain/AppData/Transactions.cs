using rygio.Helper.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class Transaction : BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
        public PaymentFor PaymentFor { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string PaymentReference { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string PaymentId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Comment { get; set; }
        public int? CollectableId { get; set; }
        public int? ExperienceId { get; set; }
        public int? PaidBy { get; set; }
    }
}
