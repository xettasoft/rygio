using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Region : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "Region";
        [Column(TypeName = "nvarchar(500)")]
        public string Decription { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Photo { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool IsLocked { get; set; } = false;
        public bool CanMemberPost { get; set; } = true;
        public int? BankAccountId { get; set; }
    }
}
