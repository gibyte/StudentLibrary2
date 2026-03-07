using StudentLibrary2.Model.Weather;
using System.Text.Json;

namespace StudentLibrary2.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.open-meteo.com/");
        }
        //https://api.open-meteo.com/v1/forecast?latitude=35&longitude=35&current_weather=true
        public async Task<WeatherDto> GetWeatherAsync(double latitude, double longitude)
        {
            var response = await _httpClient.GetAsync(
                $"v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WeatherDto>(json);
        }

    }
}
