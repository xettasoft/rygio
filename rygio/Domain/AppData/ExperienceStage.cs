using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class ExperienceStage : BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int? ExperienceId { get; set; }
        public int Stage { get; set; } = 1;
        [Column(TypeName = "nvarchar(500)")]
        public string Puzzle { get; set; }
        public bool IsMultiplePickAllowed { get; set; } = false;
        //[Column(TypeName = "bigint")]
        public int? CoordinateId { get; set; }
        public DateTime VisibleBy { get; set; } = DateTime.UtcNow;
        public virtual IEnumerable<ExperienceStageCollectible> Collectibles { get; set; }
    }
}
