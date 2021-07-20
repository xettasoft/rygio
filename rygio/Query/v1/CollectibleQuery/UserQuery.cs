using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using rygio.Helper.pagination;
using rygio.Query.v1.CollectibleQuery.RequestDto;
using rygio.Query.v1.CollectibleQuery.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Query.v1.CollectibleQuery
{
    public class UserQuery : IRequest<UserResponseDto>
    {
        public UserQueryDto pageParameter { get; set; }
        public int User { get; set; }

        public class UserQueryHandler : IRequestHandler<UserQuery, UserResponseDto>
        {
            private readonly IService<Collectable> colectibleService;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public UserQueryHandler(IService<Collectable> colectibleService, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.colectibleService = colectibleService ?? throw new ArgumentNullException(nameof(colectibleService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<UserResponseDto> Handle(UserQuery query, CancellationToken cancellationToken)
            {
                
                PageList<Collectable> result;
                result = colectibleService.GetAll(x=> x.UserId == query.User && x.IsTemplate == query.pageParameter.IsTemplate , new PageParameter { PageNumber = query.pageParameter.PageNumber, PageSize = query.pageParameter.PageSize })??throw new AppException("Error Encountered while fetching collectible.");
                return new UserResponseDto
                {
                    TotalCount = result.TotalCount,
                    PageSize = result.PageSize,
                    CurrentPage = result.CurrentPage,
                    TotalPages = result.TotalPages,
                    HasNext = result.HasNext,
                    HasPrevious = result.HasPrevious,
                    Data = mapper.Map<List<Collectable>, List<CollectibleDto>>(result.ToList()),
                };

            }
        }

    }
}
