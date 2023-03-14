using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly HealthManagementDbContext _context;

        public CityRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityByNameAsync(string cityName)
        {
            return await _context.Cities.FirstAsync(x => x.Name == cityName) 
                ?? throw new Exception($"City with Name {cityName} not found."); ;
        }
    }
}
