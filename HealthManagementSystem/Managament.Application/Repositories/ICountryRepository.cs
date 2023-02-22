using Management.Data.Models;

namespace Management.Application.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();

        Country GetCountry(string countryName);
        void AddCountry(Country country);
    }
}
