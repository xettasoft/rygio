using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Query.v1.CollectibleQuery.ResponseDto
{
    public class CollectibleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Collectible";
        public string MediaUrl { get; set; }
        public string Description { get; set; }
        public CollectableType CollectableType { get; set; }
        public CollectableState State { get; set; }
        public bool IsTemplate { get; set; } = true;
        public bool IsClaimableByStore { get; set; } = false;
        public string TermsAndConditions { get; set; }
        public decimal Value { get; set; }
        public int? UserId { get; set; }
        public int? RegionId { get; set; }
        public int? TransactionId { get; set; }
        public string Reference { get; set; }
    }
}
