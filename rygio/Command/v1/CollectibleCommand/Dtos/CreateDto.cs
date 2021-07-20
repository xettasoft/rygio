using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.CollectibleCommand.Dtos
{
    public class CreateDto
    {
        public string Name { get; set; } = "Collectible";
        public string Description { get; set; }
        public bool IsClaimableByStore { get; set; } = false;
        public string TermsAndConditions { get; set; }
        public decimal Value { get; set; }
        public int RegionId { get; set; }
    }
}
