namespace rygio.Domain.AppData
{
    public class ExperienceStageCollectible:BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int? CollectableId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? ExperienceStageId { get; set; }
        public bool IsPicked { get; set; } = false;
    }
}
