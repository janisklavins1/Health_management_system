using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IVaccinationPersonRepository
    {
        Task<List<VaccinationPersonListDto>> GetAllPersonVaccinationsAsync(int personId);
        Task AddVaccinationToPersonAsync(VaccinationPerson vaccinationPerson);
        Task EditVaccinationToPersonAsync(VaccinationPerson vaccinationPerson);
        Task<VaccinationPerson> GetVaccinationsPersonByIdAsync(int vaccinationPersonId);
    }
}
