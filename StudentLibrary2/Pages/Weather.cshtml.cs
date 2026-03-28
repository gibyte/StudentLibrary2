using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentLibrary2.Model.Weather;
using StudentLibrary2.Services;

namespace StudentLibrary2.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly WeatherService _weatherService;

        public WeatherModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [BindProperty]
        public double Latitude { get; set; }

        [BindProperty]
        public double Longitude { get; set; }

        public WeatherDto? Weather { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            try
            {
                Weather = await _weatherService
                    .GetWeatherAsync(Latitude, Longitude);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
