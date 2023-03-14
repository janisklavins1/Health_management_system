using Management.Application.Services;
using Management.Data.Models;
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

        [HttpGet]
        public async Task<ActionResult<Country>> GetCountries()
        {
            try
            {
                return Ok(await _countryService.GetAllCountriesAsync());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        [HttpGet("{countryName}")]
        public async Task<ActionResult<Country>> GetCountry(string countryName)
        {
            try
            {
                return Ok(await _countryService.GetCountryByNameAsync(countryName));

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}