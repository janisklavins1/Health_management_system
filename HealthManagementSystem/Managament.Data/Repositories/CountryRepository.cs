using Management.Application.Repositories;
using Management.Data.Context;
using Management.Data.Models;

namespace Management.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HealthManagementDbContext _context;

        public CountryRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(string countryName) 
        {
            var countryObject = _context.Countries.First(x => x.Name == countryName);

            return countryObject;
        }
    }
}