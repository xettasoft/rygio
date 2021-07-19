using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rygio.Helper
{
    public static class RygioMath
    {
        public static double ToRadians(this double angleIn10thofaDegree)
        {
            // Angle in 10th of a degree
            return (angleIn10thofaDegree * Math.PI) / 1800;
        }
    }
}
