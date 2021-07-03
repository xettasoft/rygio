using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Experience : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "Experience";
        [Column(TypeName = "nvarchar(max)")]
        public string MediaUrl { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public ExperienceType ExperienceType { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ConnectionId { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime StartBy { get; set; } = DateTime.UtcNow;
        public bool IsFree { get; set; } = false;
        public decimal Amount { get; set; }
        public int TargetMembers { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal EstimatedValue { get; set; }
        public virtual IEnumerable<ExperienceStage> Stages { get; set; }
        public virtual IEnumerable<ExperienceMember> ExperienceMembers { get; set; }

    }
}
