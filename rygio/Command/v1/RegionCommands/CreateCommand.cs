using AutoMapper;
using MediatR;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using rygio.Command.v1.RegionCommands.Dtos.Request;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace rygio.Command.v1.RegionCommands
{
    public class CreateCommand : IRequest<string>
    {
        public NewRegionDto RegionDto { get; set; }
        public int User { get; set; }

        public class CreateRegionCommandHandler : IRequestHandler<CreateCommand, string>
        {
            private readonly IRegionService regionService;
            private readonly IMapper mapper;

            public CreateRegionCommandHandler(IRegionService regionService, IMapper mapper)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                var region = mapper.Map<Region>(request.RegionDto);
                var member = new RegionResident { UserId = request.User, IsAdmin = true, IsSuperAdmin = true, CanDelete = true, CanMint = true, CanRedeem = true, IsAvailable = true };
                region.RegionResidents = new List<RegionResident> {member };
                var guid  = System.Guid.NewGuid(); ;
                region.ConnectionId = guid.ToString();
                var result = await regionService.Add(region);
                await regionService.CommitAsync();
                return "Region Created.";

            }


        }
    }
}
