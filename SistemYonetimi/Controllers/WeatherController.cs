using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using SistemYonetimi.Interfaces;
using SistemYonetimi.Models;
using System;
using System.Linq;

namespace SistemYonetimi.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly ICountryDB _db;
        private readonly IOpenWeatherMap _weather;
        private readonly Context _x;

        public WeatherController(ILogger<WeatherController> logger, ICountryDB countryDb, IOpenWeatherMap weather, Context ctx)
        {
            _logger = logger;
            _db = countryDb;
            _weather = weather;
            _x = ctx;
        }

        public IActionResult Index()
        {


            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            _x.Logs.AddRange(
                new Log() { UserIP = remoteIpAddress, UserLoginTime = DateTime.Now });
            _x.SaveChanges();

            var infos = _x.Logs.OrderByDescending(x => x.LogID).Take(5).ToList();



            return View(infos);
        }
        public IActionResult Country()
        {
            return Ok(ResponseResult.Success<List<string>>(_db.GetCountries()));
        }
        public IActionResult City(string country)
        {
            return Ok(ResponseResult.Success<List<string>>(_db.GetCities(country)));
        }
        public IActionResult GetWeather(string city)
        {
            return Ok(ResponseResult.Success<OpenWeatherMap>(_weather.Get(city)));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
