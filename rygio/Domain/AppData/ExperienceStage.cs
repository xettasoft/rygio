using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class ExperienceStage : BaseEntity
    {

        public int? ExperienceId { get; set; }
        public int Stage { get; set; } = 1;
        [Column(TypeName = "nvarchar(500)")]
        public string Puzzle { get; set; }
        public bool IsMultiplePickAllowed { get; set; } = false;
        public DateTime VisibleBy { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "geometry")]
        public Point Location { get; set; }
        public Geometry Border { get; set; }
        public IEnumerable<ExperienceStageCollectible> Collectibles { get; set; }
    }
}
