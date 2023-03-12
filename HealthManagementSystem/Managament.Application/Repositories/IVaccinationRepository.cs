using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IVaccinationRepository
    {
        Task<Vaccination> GetVaccinationByIdAsync(int id);
    }
}
