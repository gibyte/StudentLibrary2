using System.Text.Json.Serialization;

namespace StudentLibrary2.Model.Weather
{
    public class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("weathercode")]
        public int WeatherCode { get; set; }
    }
}
