using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
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
