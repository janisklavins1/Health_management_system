using Management.Application.Repositories;
using Management.Data.Models;

namespace Management.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task AddCountryAsync(Country country)
        {
            await _countryRepository.AddCountryAsync(country);
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _countryRepository.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryByNameAsync(string countryName) 
        {
            return await _countryRepository.GetCountryByNameAsync(countryName);
        }
    }
}
