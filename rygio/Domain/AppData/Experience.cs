using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Experience : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "Experience";
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public ExperienceType ExperienceType { get; set; }
        public int? UserId { get; set; }
        public bool IsPrivate { get; set; } = false;
        
    }
}
