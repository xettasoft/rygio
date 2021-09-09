using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using rygio.Query.v1.CollectibleQuery.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Query.v1.CollectibleQuery
{
    public class SingleQuery : IRequest<CollectibleDto>
    {
        public int Collectible { get; set; }
        public int User { get; set; }

        public class SingleQueryHandler : IRequestHandler<SingleQuery, CollectibleDto>
        {
            private readonly IService<Collectable> colectibleService;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public SingleQueryHandler(IService<Collectable> colectibleService, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.colectibleService = colectibleService ?? throw new ArgumentNullException(nameof(colectibleService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<CollectibleDto> Handle(SingleQuery query, CancellationToken cancellationToken)
            {

               
                var result = await colectibleService.GetSingle(x => x.Id == query.Collectible && x.State != Helper.enums.CollectableState.IsClaimed) ?? throw new AppException("Error Encountered while fetching collectible.");
                return mapper.Map<CollectibleDto>(result);

            }
        }

    }
}
