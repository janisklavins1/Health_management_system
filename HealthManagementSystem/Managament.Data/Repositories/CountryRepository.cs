using Management.Application.Repositories;
using Management.Data.Context;
using Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HealthManagementDbContext _context;

        public CountryRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public async Task<Country> GetCountryByNameAsync(string countryName) 
        {
            return await _context.Countries.FirstAsync(x => x.Name == countryName);
        }
    }
}