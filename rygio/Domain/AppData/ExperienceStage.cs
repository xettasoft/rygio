using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class ExperienceStage : BaseEntity
    {
        public int? ExperienceId { get; set; }
        public int? CollectableId { get; set; }
        public int Stage { get; set; } = 1;
        public bool IsExperienced { get; set; } = false;
        [Column(TypeName = "nvarchar(500)")]
        public string Puzzle { get; set; }
        public int? CoordinateId { get; set; }
    }
}
