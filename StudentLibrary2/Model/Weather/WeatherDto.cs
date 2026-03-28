using System.Text.Json.Serialization;

namespace StudentLibrary2.Model.Weather
{
    public class WeatherDto
    {
        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
