namespace rygio.Domain.AppData
{
    public class PostMember : BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int? PostId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
    }
}
