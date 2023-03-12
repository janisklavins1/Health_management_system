using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IAllergyPersonRepository
    {
        Task<List<AllergyPersonListDto>> GetAllPersonAllergiesAsync(int personId);
        Task AddAllergyToPersonAsync(AllergyPerson allergyPerson);
        Task EditAllergyToPersonAsync(AllergyPerson allergyPerson);
        Task<AllergyPerson> GetAllergiesPersonByIdAsync(int allergyPersonId);
    }
}
