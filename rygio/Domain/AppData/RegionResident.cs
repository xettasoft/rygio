namespace rygio.Domain.AppData
{
    public class RegionResident : BaseEntity
    {
        public int? RegionId { get; set; }
        public int? UserId { get; set; }
        public bool IsSuperAdmin { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool IsBlocked { get; set; } = false;
        public bool IsAvailable { get; set; } = false;
        public bool CanMint { get; set; } = false;
        public bool CanRedeem { get; set; } = false;
        public bool CanDelete { get; set; } = false;
    }
}
