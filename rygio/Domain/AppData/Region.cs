using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class Region : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; } = "Region";
        [Column(TypeName = "nvarchar(500)")]
        public string Decription { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Photo { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool IsLocked { get; set; } = false;
        public bool CanMemberPost { get; set; } = true;
        public int? BankAccountId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ConnectionId { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Reference { get; set; }
        [Column(TypeName = "geometry")]
        public Point Location { get; set; }
        public Geometry Border { get; set; }
        public double Radius { get; set; }
        public IEnumerable<Collectable> Collectables { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<RegionResident> RegionResidents { get; set; }
    }
}
