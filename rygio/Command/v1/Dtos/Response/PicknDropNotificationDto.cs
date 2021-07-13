using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Command.v1.Dtos.Response
{
    public class PicknDropNotificationDto
    {
        public List<CoordinateDto> Coordinates { get; set; }
        public string Message { get; set; }
    }
}
