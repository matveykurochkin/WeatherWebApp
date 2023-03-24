using System.Web;

namespace WeatherWebApp.Models
{
    public class WeatherInformation
    {
        public string? icon { get; set; }
        public string? description { get; set; }
        public int humidity { get; set; }
        public double temp { get; set; }
        public double speed { get; set; }

        public async Task Weather(string? cityName)
        {
            var tokenWeatherAPI = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                            .Build()
                            .GetSection("APIWeather")["tokenWeather"];

            HttpClient client = new HttpClient();

            var url = $"https://api.openweathermap.org/data/2.5/weather?q={HttpUtility.UrlEncode(cityName)}&appid={HttpUtility.UrlEncode(tokenWeatherAPI)}&units=metric";

            var weather = await client.GetFromJsonAsync<Root>(url);

            if (weather != null)
            {
                temp = Math.Round(weather.main.temp);
                speed = weather.wind.speed;
                description = weather.weather.ElementAt(0).description;
                icon = $"http://openweathermap.org/img/wn/{weather?.weather?.ElementAt(0).icon}@2x.png";
                humidity = weather.main.humidity;
            }

            Console.WriteLine($"temp:{temp},icon:{icon}");
        }

        public string? Url(string? cityName)
        {
            var tokenWeatherAPI = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build()
                .GetSection("APIWeather")["tokenWeather"];
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={HttpUtility.UrlEncode(cityName)}&appid={HttpUtility.UrlEncode(tokenWeatherAPI)}&units=metric";
            return url;
        }
    }
}
