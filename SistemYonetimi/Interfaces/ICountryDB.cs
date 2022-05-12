using System.Collections.Generic;

namespace SistemYonetimi.Interfaces
{
    public interface ICountryDB
    {
        List<string> GetCountries();
        List<string> GetCities(string country);
    }
}
