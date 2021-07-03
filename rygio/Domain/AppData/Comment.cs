﻿using System;
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
        //[Column(TypeName = "bigint")]
        public int? UserId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? PostId { get; set; }
        public virtual IEnumerable<Reply> Replies { get; set; }
    }
}
