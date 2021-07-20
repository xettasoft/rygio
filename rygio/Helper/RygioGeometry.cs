using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Helper
{
    public class RygioGeometry
    {
        public static Point LatLngMaker(double lat,double lng) {
            
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return geometryFactory.CreatePoint(new Coordinate(lng, lat));
        }

        public static Geometry GeometryMaker(double lat, double lng,double radius)
        {
            if (radius <= 0) throw new AppException("Invalid Radius");
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var gsf = new GeometricShapeFactory(geometryFactory);
            gsf.Centre = new Coordinate(lng, lat);
            //gsf.Size = request.RegionDto.Radius;
            gsf.Width = radius / 111320d;
            gsf.Height = radius / (40075000 * Math.Cos(RygioMath.ToRadians(radius)) / 360);
            gsf.NumPoints = 60;
            return gsf.CreateEllipse();
        }
    }
}
