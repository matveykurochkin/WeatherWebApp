using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherWebApp.Models;
using static WeatherWebApp.Models.WeatherInformation;

namespace WeatherWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string cityName)
        {
            if (cityName != null) {
                _logger.LogInformation($"Search sucsses, name of the city: {cityName}");
                WeatherInformation weatherInformation = new WeatherInformation();
                await weatherInformation.Weather(cityName);
                _logger.LogInformation($"{weatherInformation.Url(cityName)}");
                Console.WriteLine($"{weatherInformation.icon}");
                return View("Index", weatherInformation);
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}