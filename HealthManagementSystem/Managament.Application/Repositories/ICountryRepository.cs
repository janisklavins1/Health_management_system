using Management.Data.Models;

namespace Management.Application.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountriesAsync();

        Task<Country> GetCountryByNameAsync(string countryName);
        Task AddCountryAsync(Country country);
    }
}
