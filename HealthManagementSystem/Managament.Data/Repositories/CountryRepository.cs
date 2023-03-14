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

        public async Task AddCountryAsync(Country country)
        {
            _ = await _context.Countries.AddAsync(country) ??
                throw new Exception($"Couldn't add Country with Name {country.Name}.");

            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var countries = await _context.Countries.ToListAsync();

            if (countries.Count <= 0)
            {
                throw new Exception($"No Countries to display");
            }

            return countries;
        }

        public async Task<Country> GetCountryByNameAsync(string countryName)
        {
            return await _context.Countries.FirstAsync(x => x.Name == countryName)
                ?? throw new Exception($"County with Name {countryName} not found."); ;
        }
    }
}