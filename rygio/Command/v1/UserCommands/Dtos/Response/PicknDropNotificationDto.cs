using System.Collections.Generic;

namespace rygio.Command.v1.Dtos.Response
{
    public class PicknDropNotificationDto
    {
        public List<CoordinateDto> Coordinates { get; set; }
        public string Message { get; set; }
    }
}
