using Microsoft.AspNetCore.SignalR;
using rygio.Command.v1.RegionCommands.Dtos.Request;
using rygio.Hubs.V1.Dtos;
using rygio.Query.v1.InstanceQuery.Dtos.Request;
using System.Threading.Tasks;

namespace rygio.Hubs.V1
{
    public class RegionHub : Hub<IHubClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            
            await Clients.All.ReceiveMessage(message);
        }

        public async Task SubscribeToRegionActivity(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).RegionSubscription("You have subscribe for notification");
        }

        
    }
}
