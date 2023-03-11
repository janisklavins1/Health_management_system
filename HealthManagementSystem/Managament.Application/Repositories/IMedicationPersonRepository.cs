using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IMedicationPersonRepository
    {
        Task<List<MedicationPerson>> GetAllPersonMedicationsAsync(int personId);
        Task AddMedicationToPersonAsync(MedicationPerson medicationPerson);
        Task RemoveMedicationFromPersonAsync(MedicationPerson medicationPerson);
    }
}
