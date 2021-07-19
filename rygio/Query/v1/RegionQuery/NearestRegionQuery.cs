using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.Spatial;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using rygio.Helper.pagination;
using rygio.Query.v1.RegionQuery.Dtos.Request;
using rygio.Query.v1.RegionQuery.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rygio.Query.v1.RegionQuery
{
    public class NearestRegionQuery : IRequest<NearestRegionResponseDto>
    {
        public NearestRegionDto pageParameter { get; set; }

        public class NearestRegionQueryHandler : IRequestHandler<NearestRegionQuery, NearestRegionResponseDto>
        {
            private readonly IRegionService regionService;
            private readonly IMapper mapper;
            private AppSettings _appSettings;

            public NearestRegionQueryHandler(IRegionService regionService, IMapper mapper, IOptions<AppSettings> appSettings)
            {
                this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            }



            public async Task<NearestRegionResponseDto> Handle(NearestRegionQuery query, CancellationToken cancellationToken)
            {
                var point = RygioGeometry.LatLngMaker(query.pageParameter.Latitude,query.pageParameter.Longitude);
                PageList<Region> result;
                result =  regionService.GetNearestRegionsWithhFilter( x=>!x.IsDeleted,new PageParameter { PageNumber = query.pageParameter.PageNumber, PageSize = query.pageParameter.PageSize },point);
                return new NearestRegionResponseDto
                {
                    TotalCount = result.TotalCount,
                    PageSize = result.PageSize,
                    CurrentPage = result.CurrentPage,
                    TotalPages = result.TotalPages,
                    HasNext = result.HasNext,
                    HasPrevious = result.HasPrevious,
                    Data = mapper.Map<List<Region>, List<RegionQueryDto>>(result.ToList()),
                };

            }
        }

        }
    }
