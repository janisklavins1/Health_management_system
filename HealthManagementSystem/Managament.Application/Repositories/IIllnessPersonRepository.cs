using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IIllnessPersonRepository
    {
        Task<List<IllnessPersonListDto>> GetAllPersonIllnessesAsync(int personId);
        Task AddIllnessToPersonAsync(IllnessPerson illnessPerson);
        Task EditIllnessToPersonAsync(IllnessPerson illnessPerson);
        Task<IllnessPerson> GetIllnessesPersonByIdAsync(int illnessPersonId);
    }
}
