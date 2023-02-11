using Health.Application.Services;
using Health.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public WeatherForecastController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Country> Get()
        {
            return _countryService.GetAllCountries();
        }
    }
}