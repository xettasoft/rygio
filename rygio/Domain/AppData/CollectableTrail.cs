﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Domain.AppData
{
    public class CollectableTrail : BaseEntity
    {
        //[Column(TypeName = "bigint")]
        public int? CollectableId { get; set; }
        //[Column(TypeName = "bigint")]
        public int? From { get; set; }
        //[Column(TypeName = "bigint")]
        public int? To { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Message { get; set; }
    }
}