using HealthManagementSystem.Dto;
using Management.Application.Interfaces;
using Management.Application.Services;
using Management.Data.Models;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Country> GetCountries()
        {
            return _countryService.GetAllCountries();
        }

        [HttpGet("{countryName}")]
        public Country GetCountry(string countryName)
        {
            return _countryService.GetCountry(countryName);
        }
    }
}