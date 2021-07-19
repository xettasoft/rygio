using NetTopologySuite.Geometries;
using rygio.Domain.AppData;
using rygio.Helper.pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rygio.Domain.Interface
{
    public interface IRegionService : IService<Region>
    {
        PageList<Region> GetNearestRegions(PageParameter pagination, Point currentLocation);
        PageList<Region> GetNearestRegionsWithhFilter(Expression<Func<Region, bool>> predicate, PageParameter pagination, Point currentLocation);
    }
}
