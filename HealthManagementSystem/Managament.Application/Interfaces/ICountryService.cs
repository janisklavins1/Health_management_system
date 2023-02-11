using Management.Data.Models;

namespace Management.Application.Services
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();
    }
}
