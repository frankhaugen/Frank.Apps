using System;
using System.Numerics;

namespace Frank.Apps.StarMap.Services
{
    public class CalculationService
    {
        private const long AstronomicUnit = 147579870700;
        public long AstronomicalUnit() => AstronomicUnit;
        public long CalculateParsec() => (180 * 60 * 60 * AstronomicUnit) / Convert.ToInt64(Math.PI);
        public decimal FromParsecToLightYearConverter(decimal lightyear) => lightyear / 3.26163626m;

        public static double ThreeDimensionalDistance(Vector3 origin, Vector3 destination)
        {
            var x = Math.Pow(origin.X - destination.X, 2);
            var y = Math.Pow(origin.Y - destination.Y, 2);
            var z = Math.Pow(origin.Z - destination.Z, 2);
            var result = Math.Sqrt(x + y + z);
            return result;
        }
    }
}
