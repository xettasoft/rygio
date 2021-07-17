
using rygio.Command.v1.Dtos.Response;
using rygio.Command.v1.RegionCommands.Dtos.Request;
using rygio.Hubs.V1.Dtos;
using rygio.Query.v1.InstanceQuery.Dtos.Request;
using System.Threading.Tasks;

namespace rygio.Hubs.V1
{
    public interface IHubClient
    {
        Task RegionSubscription(string message);
        Task ReceiveMessage(ChatMessage message);
        Task ReceiveRegionPost(PostDto dto);
        Task ReceiveRegionCollectibleAction(CollectibleActionDto dto);
        Task ReceiveRoomMessage(ChatMessage dto);
        Task ReceiveExperienceActivity(ExperienceActivityDto dto);



    }
}
