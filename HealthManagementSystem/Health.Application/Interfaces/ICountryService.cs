using Health.Domain.Models;
using System.Collections.Generic;

namespace Health.Application.Services
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();
    }
}
