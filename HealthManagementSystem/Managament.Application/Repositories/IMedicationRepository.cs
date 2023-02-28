using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IMedicationRepository
    {
        Task<Medication> GetMedication(int id);
        Task<ICollection<Medication>> GetAllMedicationsAsync();
        void AddMedication(Medication medication);

        Task EditMedicationAsync(Medication medication);
    }
}
