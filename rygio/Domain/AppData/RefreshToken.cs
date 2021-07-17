using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class RefreshToken:BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public int? UserId { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string IpAddress { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string UserAgent { get; set; }
    }
}
