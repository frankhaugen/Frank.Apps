using System;

namespace Frank.Apps.StarMap.Services
{
    public class CalculationService
    {
        private const long AstronomicUnit = 147579870700;

        public long CalculateParsec() => (180 * 60 * 60 * AstronomicUnit) / Convert.ToInt64(Math.PI);


        public decimal ParsecToLightYearConverter(decimal lightyear) => lightyear / 3.26163626m;
        public decimal LightYearToParsecConverter(decimal parsec) => parsec * 3.26163626m;
    }
}
