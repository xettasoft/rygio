using AutoMapper;
using MediatR;
using rygio.Command.v1.ExperienceCommands.Dtos;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1.ExperienceCommands
{
    public class CreateCommand : IRequest<string>
    {
        public ExperienceDto ExperienceDto { get; set; }
        public int User { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateCommand, string>
        {
            private readonly IRegionService regionService;
            private readonly IService<Collectable> collectibleService;
            private readonly IService<Experience> experienceService;
            private readonly IMapper mapper;

            public CreateCommandHandler(IService<Experience> experienceService,IService<Collectable> collectibleService, IRegionService regionService, IMapper mapper)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.experienceService = experienceService ?? throw new ArgumentNullException(nameof(experienceService));
                this.collectibleService = collectibleService ?? throw new ArgumentNullException(nameof(collectibleService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                //if (request.ExperienceDto.Stages.Where(x => x.Collectibles.Any()).Any()) throw new AppException("Experience must have at least one Collectible.");
                var experience = mapper.Map<Experience>(request.ExperienceDto);
                Region region;
                var guid = System.Guid.NewGuid();


                if (experience?.RegionId > 0)
                {
                    region = await regionService.FindSingleInclude(x => x.Id == experience.RegionId, m => m.RegionResidents.Where(r => r.UserId == request.User));
                    if (region == null) throw new AppException("The specified region does not exist.");
                    if (region.RegionResidents == null || !region.RegionResidents.Any()) throw new AppException("User is not a member of the specified region.");
                    if (!region.RegionResidents.FirstOrDefault().CanMint) throw new AppException("User does not have the required previledge.");
                    experience.UserId = null;

                }
                else
                {
                    experience.UserId = request.User;
                    experience.RegionId = null;
                }

                experience.Universal = guid.ToString();
                experience.State = Helper.enums.ExperienceState.owned;
                var result = await experienceService.Add(experience);
                await experienceService.CommitAsync();
                return "Experience Created.";


            }


        }
    }
}
