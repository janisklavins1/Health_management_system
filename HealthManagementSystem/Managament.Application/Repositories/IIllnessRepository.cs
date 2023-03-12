using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IIllnessRepository
    {
        Task<Illness> GetIllnessByIdAsync(int id);
    }
}
