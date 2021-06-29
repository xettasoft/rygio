﻿using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public TransactionStatus Status { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string PaymentReference { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string PaymentId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Comment { get; set; }
        public int? CollectableId { get; set; }
        public int? PaidBy { get; set; }
    }
}
