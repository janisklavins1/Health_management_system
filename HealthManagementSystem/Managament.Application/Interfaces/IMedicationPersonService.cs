using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Interfaces
{
    public interface IMedicationPersonService
    {
        Task<List<MedicationPerson>> GetAllPersonMedicationsAsync(int personId);
        Task AddMedicationToPersonAsync(MedicationPersonDto medicationPerson);
        Task RemoveMedicationFromPersonAsync(MedicationPerson medicationPerson);
    }
}
