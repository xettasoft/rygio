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
    public class MintCommand : IRequest<string>
    {
        public MintDto MintDto { get; set; }
        public int User { get; set; }

        public class MintCommandHandler : IRequestHandler<MintCommand, string>
        {
            private readonly IRegionService regionService;
            private readonly IService<Collectable> collectibleService;
            private readonly IMapper mapper;

            public MintCommandHandler(IService<Collectable> collectibleService, IRegionService regionService, IMapper mapper)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.collectibleService = collectibleService ?? throw new ArgumentNullException(nameof(collectibleService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(MintCommand request, CancellationToken cancellationToken)
            {
                

                var collectible = await collectibleService.GetSingle(x=>x.Id == request.MintDto.TemplateId && x.IsTemplate);
                if (collectible == null) throw new AppException("Invalid template.");
                var guid = System.Guid.NewGuid();
                collectible.Id = 0;
                collectible.UserId = request.User;


                collectible.IsTemplate = false;
                collectible.Universal = guid.ToString();
                collectible.State = Helper.enums.CollectableState.owned;
                collectible.CollectableTrails = new List<CollectableTrail> { new CollectableTrail { To = request.User, Message = "Collectible successfully minted."} };

                var result = await collectibleService.Add(collectible);
                await collectibleService.CommitAsync();
                return "Collectible minted successfully.";


            }


        }
    }
}
