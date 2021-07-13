using NetTopologySuite.Geometries;
using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.Dtos.Response
{
    public class CoordinateDto
    {
        public int Id { get; set; }
        public CoordinateType CoordinateType { get; set; }
        public bool IsAction { get; set; } = true;
        public bool IsSearchable { get; set; } = true;
        public Point Location { get; set; }
        public Geometry Border { get; set; }
        public int? ExperienceId { get; set; }
        public int? RegionId { get; set; }
        public int? PostId { get; set; }
    }
}
