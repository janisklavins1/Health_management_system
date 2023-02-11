using Health.Application.Repositories;
using Health.Domain.Models;
using System.Collections.Generic;

namespace Health.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }
    }
}
