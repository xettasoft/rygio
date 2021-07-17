
using NetTopologySuite.Geometries;
using rygio.Helper.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class Collectable : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "Collectible";
        [Column(TypeName = "nvarchar(64)")]
        public string Universal { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string MediaUrl { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public CollectableType CollectableType { get; set; }
        public CollectableState State { get; set; }
        public bool IsTemplate { get; set; } = true;
        public bool IsClaimableByStore { get; set; } = false;
        [Column(TypeName = "nvarchar(16)")]
        public string ClaimingCode { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string TermsAndConditions { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
        //[Column(TypeName = "bigint")]
        public int RegionId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? TransactionId { get; set; }
        [Column(TypeName = "geometry")]
        public Point MintedAt { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Reference { get; set; }
        public IEnumerable<CollectableTrail> CollectableTrails { get; set; }
    }
}
