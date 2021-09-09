using AutoMapper;
using MediatR;
using rygio.Command.v1.CollectibleCommand.Dtos;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1.CollectibleCommand
{
    public class TransferCommand : IRequest<string>
    {
        public TransferDto TransferDto { get; set; }
        public int User { get; set; }

        public class TransferCommandHandler : IRequestHandler<TransferCommand, string>
        {
            private readonly IRegionService regionService;
            private readonly IService<Collectable> collectibleService;
            private readonly IService<User> userService;
            private readonly IMapper mapper;

            public TransferCommandHandler(IService<Collectable> collectibleService, IService<User> userService, IRegionService regionService, IMapper mapper)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.collectibleService = collectibleService ?? throw new ArgumentNullException(nameof(collectibleService));
                this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(TransferCommand request, CancellationToken cancellationToken)
            {


                var collectible = await collectibleService.GetSingle(x => x.Id == request.TransferDto.CollectableId && x.IsTemplate == false && (x.State == Helper.enums.CollectableState.Picked || x.State == Helper.enums.CollectableState.owned));
                if (collectible == null) throw new AppException("Invalid Collectible.");
                if(collectible.UserId != request.User) throw new AppException("Transfer not permitted.");
                var user = await userService.GetSingle(x => x.Id == request.TransferDto.To);
                if (user == null) throw new AppException("User does not exist.");
                if (!user.IsActive) throw new AppException("User can not recieve collectable.");
                collectible.UserId = user.Id;
                collectible.State = Helper.enums.CollectableState.owned;
                collectible.CollectableTrails = new List<CollectableTrail> { new CollectableTrail { To = user.Id, From = request.User, Message = "Collectible transfered." } };
                await collectibleService.CommitAsync();
                return "Collectible successfully transfered to "+ user.Name;


            }


        }
    }
}
