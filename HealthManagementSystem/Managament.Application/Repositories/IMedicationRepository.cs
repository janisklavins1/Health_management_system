using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IMedicationRepository
    {
        Task<Medication> GetMedicationAsync(int id);
        Task<ICollection<Medication>> GetAllMedicationsAsync();
        Task AddMedicationAsync(Medication medication);
        Task EditMedicationAsync(Medication medication);
    }
}
