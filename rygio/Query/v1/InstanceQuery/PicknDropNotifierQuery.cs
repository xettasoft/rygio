using MediatR;
using Microsoft.AspNetCore.SignalR;
using rygio.Hubs.V1;
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

            private IHubContext<RegionHub, IHubClient> _notificationHub;

            public PicknDropNotifierQueryHandler(IHubContext<RegionHub, IHubClient> hubContext)
            {
                _notificationHub = hubContext;
            }

            public async Task<bool> Handle(PicknDropNotifierQuery request, CancellationToken cancellationToken)
            {
                
                //await _notificationHub.Clients.All.ReceiveMessage(new InstanceQuery.Dtos.Request.ChatMessage { User = "Rygio", Message = "Gentle reminder that we are soon going to launch our product"});
                await _notificationHub.Clients.Group("region_1").RegionSubscription("Hello roomies");
                
                //NotificationHub.

                return true;

            }


        }
    }
}
