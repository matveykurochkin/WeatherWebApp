﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherWebApp.Models;

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
            try
            {
                if (cityName != null)
                {
                    WeatherInformation weatherInformation = new WeatherInformation();
                    await weatherInformation.Weather(cityName);
                    _logger.LogInformation($"Search sucsses, name of the city: {cityName}\n" +
                    $"\ttemp: {weatherInformation.temp}\n" +
                    $"\tdescription: {weatherInformation.description}\n" +
                    $"\ticon: {weatherInformation.icon}\n" +
                    $"\thumidity: {weatherInformation.humidity}\n" +
                    $"\twind speed: {weatherInformation.speed}\n" +
                    $"\tyour URL: {weatherInformation.Url(cityName)}");
                    return View("Index", weatherInformation);
                }
                else
                    return View("Index");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error message: {ex.Message}");
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