using HealthManagementSystem.Dto;
using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface IAllergyPersonService
    {
        Task<List<AllergyPersonListDto>> GetAllPersonAllergiesAsync(int personId);
        Task AddAllergyToPersonAsync(AllergyPersonDto request);
        Task EditAllergyToPersonAsync(int allergyPersonId, AllergyPersonEditDto request);
    }
}
