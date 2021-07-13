using MediatR;
using Microsoft.AspNetCore.SignalR;
using rygio.Hubs.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Query.v1
{
    public class PicknDropNotifierQuery : IRequest<bool>
    {
        public string group { get; set; }

        public class PicknDropNotifierQueryHandler : IRequestHandler<PicknDropNotifierQuery, bool>
        {
            //private readonly IUserRepository userRepository;

            private IHubContext<NotificationHub, IHubClient> _notificationHub;

            public PicknDropNotifierQueryHandler(IHubContext<NotificationHub, IHubClient> hubContext)
            {
                _notificationHub = hubContext;
            }

            public async Task<bool> Handle(PicknDropNotifierQuery request, CancellationToken cancellationToken)
            {

                ///await _notificationHub.Clients.Group("").NotifyClient(new Dtos.Respond.PicknDropNotificationDto { Message="Noting to show"});
                //NotificationHub.

                return true;

            }


        }
    }
}
