using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.DataAccess.Services
{
    public class NtsGeometryServicesEx : NetTopologySuite.NtsGeometryServices
    {
        public NtsGeometryServicesEx() { }

        public NtsGeometryServicesEx(CoordinateSequenceFactory coordinateSequenceFactory,PrecisionModel precisionModel, int srid)
            : base(coordinateSequenceFactory,precisionModel, srid)
        {
        }


        protected override GeometryFactory CreateGeometryFactoryCore(
            PrecisionModel precisionModel,
            int srid,
            CoordinateSequenceFactory coordinateSequenceFactory)
        {
            return new GeometryFactoryEx(precisionModel, srid, coordinateSequenceFactory);
        }
    }
}
