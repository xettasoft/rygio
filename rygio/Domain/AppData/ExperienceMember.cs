namespace rygio.Domain.AppData
{
    public class ExperienceMember : BaseEntity
    {

        public int ExperienceId { get; set; }
        public int? UserId { get; set; }
        public bool HasPaid { get; set; } = false;
    }
}
