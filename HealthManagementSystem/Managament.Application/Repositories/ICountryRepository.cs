using Management.Data.Models;

namespace Management.Application.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();

        Task<Country> GetCountryByNameAsync(string countryName);
        void AddCountry(Country country);
    }
}
