using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IMedicationPersonRepository
    {
        Task<List<MedicationPersonListDto>> GetAllPersonMedicationsAsync(int personId);
        Task AddMedicationToPersonAsync(MedicationPerson medicationPerson);
        Task EditMedicationToPersonAsync(MedicationPerson medicationPerson);
        Task<MedicationPerson> GetMedicationPersonByIdAsync(int medicationPersonId);
    }
}
