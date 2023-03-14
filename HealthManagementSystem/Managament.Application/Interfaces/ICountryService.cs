using Management.Data.Models;

namespace Management.Application.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();

        Task<Country> GetCountryByNameAsync(string countryName);

        Task AddCountryAsync(Country country);
    }
}
