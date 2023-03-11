using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface IMedicationPersonService
    {
        Task<List<MedicationPersonListDto>> GetAllPersonMedicationsAsync(int personId);
        Task AddMedicationToPersonAsync(MedicationPersonDto medicationPerson);
        Task EditMedicationToPersonAsync(int medicationPersonId, MedicationPersonEditDto medicationPerson);
    }
}
