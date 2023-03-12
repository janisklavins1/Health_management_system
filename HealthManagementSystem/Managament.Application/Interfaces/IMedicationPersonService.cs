using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface IMedicationPersonService
    {
        Task<List<MedicationPersonListDto>> GetAllPersonMedicationsAsync(int personId);
        Task AddMedicationToPersonAsync(MedicationPersonDto request);
        Task EditMedicationToPersonAsync(int medicationPersonId, MedicationPersonEditDto request);
    }
}
