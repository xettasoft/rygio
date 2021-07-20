namespace rygio.Domain.AppData
{
    public class ExperienceStageCollectible:BaseEntity
    {
        public int? CollectableId { get; set; }
        public int ExperienceStageId { get; set; }
        public bool IsPicked { get; set; } = false;
    }
}
