using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Sphere : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Connection { get; set; }
        [Column(TypeName = "geometry")]
        public Point Location { get; set; }
        public Geometry Border { get; set; }
    }
}
