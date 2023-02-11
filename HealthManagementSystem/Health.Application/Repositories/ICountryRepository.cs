using Health.Domain.Models;
using System.Collections.Generic;

namespace Health.Application.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
    }
}
