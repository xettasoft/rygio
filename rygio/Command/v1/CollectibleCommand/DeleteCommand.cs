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
    public class DeleteCommand : IRequest<string>
    {
        public DeleteDto DeleteDto { get; set; }
        public int User { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, string>
        {
            private readonly IService<Collectable> collectibleService;
            private readonly IService<RegionResident> residentService;
            private readonly IMapper mapper;

            public DeleteCommandHandler(IService<Collectable> collectibleService, IService<RegionResident> residentService, IMapper mapper)
            {
                this.collectibleService = collectibleService ?? throw new ArgumentNullException(nameof(collectibleService));
                this.residentService = residentService ?? throw new ArgumentNullException(nameof(residentService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {


                var collectible = await collectibleService.GetSingle(x => x.Id == request.DeleteDto.Collectable && x.IsTemplate );
                if (collectible == null) throw new AppException("Invalid Collectible Template.");

                if (collectible.RegionId != null) {
                    var resident = await residentService.GetSingle(x => x.UserId == request.User);
                    if (resident == null) throw new AppException("Action not permitted.");
                    if(! resident.CanDelete) throw new AppException("Action not permitted.");
                }
                else if (collectible.UserId != request.User) throw new AppException("Action not permitted.");

                collectibleService.Delete(collectible);
                await collectibleService.CommitAsync();
                return "Collectible template deleted";


            }


        }
    }
}
