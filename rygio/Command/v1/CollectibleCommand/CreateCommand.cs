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
    public class CreateCommand : IRequest<string>
    {
        public CreateDto CreateDto { get; set; }
        public int User { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateCommand, string>
        {
            private readonly IRegionService regionService;
            private readonly IService<Collectable> collectibleService;
            private readonly IMapper mapper;

            public CreateCommandHandler(IService<Collectable> collectibleService,IRegionService regionService, IMapper mapper)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.collectibleService = collectibleService ?? throw new ArgumentNullException(nameof(collectibleService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                if (request.CreateDto.Value <= 0) throw new AppException("Collectible template must have a value greater than or equal to $1.00");

                var collectible = mapper.Map<Collectable>(request.CreateDto);
                Region region;
                var guid = System.Guid.NewGuid();


                if (collectible?.RegionId > 0)
                {
                    region = await regionService.FindSingleInclude(x => x.Id == collectible.RegionId,m => m.RegionResidents.Where(r=>r.UserId == request.User));
                    if (region == null) throw new AppException("The specified region does not exist.");
                    if (region.RegionResidents == null || !region.RegionResidents.Any()) throw new AppException("User is not a member of the specified region.");
                    if(! region.RegionResidents.FirstOrDefault().CanMint ) throw new AppException("User does not have the required previledge.");
                    collectible.MintedAt = region.Location;
                    collectible.UserId = null;

                }
                else
                {
                    collectible.UserId = request.User;
                    collectible.IsClaimableByStore = false;
                    collectible.RegionId = null;
                }

                collectible.IsTemplate = true;
                collectible.Universal = guid.ToString();
                collectible.State = Helper.enums.CollectableState.NotSet;
                collectible.CollectableType = Helper.enums.CollectableType.GiftCard;
                var result = await collectibleService.Add(collectible);
                await collectibleService.CommitAsync();
                return "Collectible Template Created.";


            }


        }
    }
}
