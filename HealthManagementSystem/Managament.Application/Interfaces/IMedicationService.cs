using HealthManagementSystem.Dto;
using Management.Domain.Models;

namespace Management.Application.Interfaces
{
    public interface IMedicationService
    {
        Task<Medication> GetMedicationAsync(int id);
        Task<ICollection<Medication>> GetAllMedicationsAsync();
        Task AddMedicationAsync(MedicationDto medication);

        Task EditMedicationAsync(int id, MedicationDto request);
    }
}
