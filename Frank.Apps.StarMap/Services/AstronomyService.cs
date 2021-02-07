namespace Frank.Apps.StarMap.Services
{
    public class AstronomyService
    {
        //Function to determin star type from 
        public int DetermineStarType(string Spectrum)
        {
            //Initializing integer variable
            int SpectralTypeVal;

            //If statement to determin spectral type of star
            if (Spectrum.Contains("O"))
            {
                SpectralTypeVal = 1;
            }
            else if (Spectrum.Contains("B"))
            {
                SpectralTypeVal = 2;
            }
            else if (Spectrum.Contains("A"))
            {
                SpectralTypeVal = 3;
            }
            else if (Spectrum.Contains("F"))
            {
                SpectralTypeVal = 4;
            }
            else if (Spectrum.Contains("G"))
            {
                SpectralTypeVal = 5;
            }
            else if (Spectrum.Contains("K"))
            {
                SpectralTypeVal = 6;
            }
            else if (Spectrum.Contains("M"))
            {
                SpectralTypeVal = 7;
            }
            else
            {
                SpectralTypeVal = 0;
            }

            //return numbercode (0-7) to indicate a star's spectral type
            return SpectralTypeVal;
        }
    }
}
