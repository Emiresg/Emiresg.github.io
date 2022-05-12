using SistemYonetimi.Models;

namespace SistemYonetimi.Interfaces
{
    public interface IOpenWeatherMap
    {
        OpenWeatherMap Get(string city);
    }
}
