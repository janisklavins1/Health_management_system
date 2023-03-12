using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IAllergyRepository
    {
        Task<Allergy> GetAllergyByIdAsync(int id);
    }
}
