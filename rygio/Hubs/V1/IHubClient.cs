
using rygio.Command.v1.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Hubs.V1
{
    public interface IHubClient
    {
        Task NotifyClient(PicknDropNotificationDto items);
    }
}
