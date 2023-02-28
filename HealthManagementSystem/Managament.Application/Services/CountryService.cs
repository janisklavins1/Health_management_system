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

        public void AddCountry(Country country)
        {
            _countryRepository.AddCountry(country);
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }

        public Country GetCountry(string countryName) 
        {
            return _countryRepository.GetCountry(countryName);
        }
    }
}
