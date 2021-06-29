using GeoAPI.Geometries;
using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Collectable : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "Collectable";
        [Column(TypeName = "nvarchar(128)")]
        public string Photo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public CollectableType CollectableType { get; set; }
        public CollectableState State { get; set; }
        public bool IsClaimed { get; set; } = false;
        public bool IsClaimableByStore { get; set; } = true;
        [Column(TypeName = "nvarchar(16)")]
        public string ClaimingCode { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string TermsAndConditions { get; set; }
        public decimal Value { get; set; }
        public int? UserId { get; set; }
        public int RegionId { get; set; }
        public int? TransactionId { get; set; }
        [Column(TypeName = "geometry")]
        public IPoint MintedAt { get; set; }
    }
}
