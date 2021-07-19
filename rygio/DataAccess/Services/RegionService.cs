using Microsoft.Extensions.Options;
using NetTopologySuite.Geometries;
using rygio.Domain.AppData;
using rygio.Domain.Interface;
using rygio.Helper;
using rygio.Helper.pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rygio.DataAccess.Repository
{
    public class RegionService: Service<Region>, IRegionService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public RegionService(ApplicationDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _appSettings = appSettings.Value;

        }

        public PageList<Region> GetNearestRegions(PageParameter pagination, Point currentLocation)
        {
            var result = _context.Regions.OrderBy(c => c.Location.Distance(currentLocation));
            return PageList<Region>.ToPagedList(source: result, pagination.PageNumber, pagination.PageSize);
        }

        public PageList<Region> GetNearestRegionsWithhFilter(Expression<Func<Region, bool>> predicate, PageParameter pagination, Point currentLocation)
        {
           
            var result =  _context.Regions.Where(predicate).OrderBy(c => c.Location.Distance(currentLocation));
            return PageList<Region>.ToPagedList(source: result, pagination.PageNumber, pagination.PageSize);


        }
    }
}
