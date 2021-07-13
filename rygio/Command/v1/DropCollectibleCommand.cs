using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using rygio.Command.v1.Dtos.Response;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Hubs.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1
{
    public class DropCollectibleCommand : IRequest<bool>
    {
        public string token { get; set; }

        public class DropCollectibleCommandHandler : IRequestHandler<DropCollectibleCommand, bool>
        {
            private readonly IUserService userRepository;
            private readonly IMapper mapper;
            private IHubContext<NotificationHub, IHubClient> _notificationHub;

            public DropCollectibleCommandHandler(IUserService userRepository, IMapper mapper, IHubContext<NotificationHub, IHubClient> hubContext)
            {
                this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _notificationHub = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            }

            public async Task<bool> Handle(DropCollectibleCommand request, CancellationToken cancellationToken)
            {


                await _notificationHub.Clients.Group("").NotifyClient(new PicknDropNotificationDto { Message = "Noting to show" });
               // var newtoken = await userRepository.RefreshToken(request.token);

                return true;

            }


        }
    }
}
