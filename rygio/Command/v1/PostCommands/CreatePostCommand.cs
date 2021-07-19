using AutoMapper;
using MediatR;
using rygio.Command.v1.PostCommands.Dtos;
using rygio.Domain.Interface;
using rygio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Command.v1.PostCommands
{
    public class CreatePostCommand : IRequest<string>
    {
        public MakePostDto PostDto { get; set; }
        public int User { get; set; }

        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, string>
        {
            private readonly IRegionService regionService;
            private readonly IMapper mapper;

            public CreatePostCommandHandler(IRegionService regionService, IMapper mapper)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                var point = RygioGeometry.LatLngMaker(request.PostDto.Latitude, request.PostDto.Longitude);
                var region = await regionService.GetSingle(x => x.Id == request.PostDto.Region);
                if (region == null) throw new AppException("The region specified does not exist.");
                if (!region.Border.Contains(point)) throw new AppException("Your Post can not be created because you are not in the specified region.");

                return "post Created.";


            }


        }
    }
}
