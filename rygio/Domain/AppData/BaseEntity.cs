using System;

namespace rygio.Domain.AppData
{
    public class BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
