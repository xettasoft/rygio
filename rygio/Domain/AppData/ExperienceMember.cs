﻿namespace rygio.Domain.AppData
{
    public class ExperienceMember : BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int? ExperienceId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
        public bool HasPaid { get; set; } = false;
    }
}
