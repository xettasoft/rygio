using NetTopologySuite.Geometries;
using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? UserId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ConnectionId { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime StartBy { get; set; } = DateTime.UtcNow;
        public bool IsFree { get; set; } = false;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public int TargetMembers { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal EstimatedValue { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Reference { get; set; }
        [Column(TypeName = "geometry")]
        public Point Location { get; set; }
        public Geometry Border { get; set; }
        public IEnumerable<ExperienceStage> Stages { get; set; }
        public IEnumerable<ExperienceMember> ExperienceMembers { get; set; }

    }
}
