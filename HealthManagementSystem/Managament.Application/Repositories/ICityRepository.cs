using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface ICityRepository
    {
        Task<City> GetCityByNameAsync(string cityName);
    }
}
