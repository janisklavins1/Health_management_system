using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface IVaccinationPersonService
    {
        Task<List<VaccinationPersonListDto>> GetAllPersonVaccinationsAsync(int personId);
        Task AddVaccinationToPersonAsync(VaccinationPersonDto request);
        Task EditVaccinationToPersonAsync(int vaccinationPersonId, VaccinationPersonEditDto request);
    }
}
