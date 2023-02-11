using Health.Application.Repositories;
using Health.Domain.Models;
using System.Collections.Generic;

namespace Health.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository _countryRepository)
        {
            countryRepository = _countryRepository;
        }

        public List<Country> GetAllCountries()
        {
            return countryRepository.GetAllCountries();
        }
    }
}
