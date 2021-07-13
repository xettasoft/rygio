
using NetTopologySuite.Geometries;
using rygio.Helper.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace rygio.Domain.AppData
{
    public class Coordinate : BaseEntity
    {
        public CoordinateType CoordinateType { get; set; }
        public bool IsAction { get; set; } = true;
        public bool IsSearchable { get; set; } = true;
        [Column(TypeName = "geometry")]
        public Point Location { get; set; }
        public Geometry Border { get; set; }
        //[Column(TypeName = "bigint")]
        public int? ExperienceId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? RegionId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? PostId { get; set; }

    }
}
