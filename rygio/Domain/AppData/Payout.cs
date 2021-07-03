using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace rygio.Domain.AppData
{
    public class Payout : BaseEntity
    {
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string PaymentReference { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string PaymentId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Comment { get; set; }
        //[Column(TypeName = "bigint")]
        public int? CollectableId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? PaidBy { get; set; }
        //[Column(TypeName = "bigint")]
        public int? BankAccountId { get; set; }
    }
}
