using Health.Application.Repositories;
using Health.Domain.Models;
using System.Collections.Generic;

namespace Health.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly List<Country> createCountriesList = new List<Country>()
        {
            new Country() { Id = 1, Name = "Latvia", CountryCode = "LV" },
            new Country() { Id = 2, Name = "Estonia", CountryCode = "EE" },
            new Country() { Id = 3, Name = "Lithuania", CountryCode = "LT" }
        };

        public List<Country> GetAllCountries()
        {
            return createCountriesList;
        }
    }
}