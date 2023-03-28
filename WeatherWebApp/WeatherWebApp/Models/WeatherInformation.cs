using System.Web;

namespace WeatherWebApp.Models
{
    public class WeatherInformation
    {
        public string? icon { get; set; }
        public string? description { get; set; }
        public int humidity { get; set; }
        public double? temp { get; set; }
        public double? speed { get; set; }
        public string? city { get; set; }

        string tokenWeatherAPI = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build()
                .GetSection("APIWeather")["tokenWeather"];

        public async Task Weather(string? cityName)
        {

            HttpClient client = new HttpClient();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={HttpUtility.UrlEncode(cityName)}&appid={HttpUtility.UrlEncode(tokenWeatherAPI)}&units=metric";

            Root? weather = await client.GetFromJsonAsync<Root>(url);

            if (weather is not null && weather.cod != 404)
            {
                temp = Math.Round(weather!.main!.temp);
                speed = weather.wind?.speed;
                description = weather?.weather?.ElementAt(0).description;
                icon = $"http://openweathermap.org/img/wn/{weather?.weather?.ElementAt(0).icon}@2x.png";
                humidity = weather!.main.humidity;
                city = cityName;
            }
        }

        public string? Url(string? cityName)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={HttpUtility.UrlEncode(cityName)}&appid={HttpUtility.UrlEncode(tokenWeatherAPI)}&units=metric";
            return url;
        }
    }
}
