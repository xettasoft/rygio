using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.CollectibleCommand.Dtos
{
    public class TransferDto
    {
        public int CollectableId { get; set; }
        public int To { get; set; }
        public string Comment { get; set; }
    }
}
