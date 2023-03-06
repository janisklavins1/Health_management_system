using Management.Data.Models;

namespace Management.Application.Services
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();

        Task<Country> GetCountryByNameAsync(string countryName);

        void AddCountry(Country country);
    }
}
