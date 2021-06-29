using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class Comment : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
    }
}
