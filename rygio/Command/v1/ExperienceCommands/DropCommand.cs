using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.Interface;
using rygio.Hubs.V1;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1
{
    public class DropCommand : IRequest<bool>
    {
        public string token { get; set; }

        public class DropCollectibleCommandHandler : IRequestHandler<DropCommand, bool>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private IHubContext<RegionHub, IHubClient> _notificationHub;

            public DropCollectibleCommandHandler(IUserService userRepository, IMapper mapper, IHubContext<RegionHub, IHubClient> hubContext)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _notificationHub = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            }

            public async Task<bool> Handle(DropCommand request, CancellationToken cancellationToken)
            {


                //await _notificationHub.Clients.Group("").NotifyClient(new PicknDropNotificationDto { Message = "Noting to show" });
                //await _notificationHub.Clients.All.ReceiveMessage(new PicknDropNotificationDto { Message = "Noting to show or is there something" });
                // var newtoken = await userRepository.RefreshToken(request.token);

                return true;

            }


        }
    }
}
