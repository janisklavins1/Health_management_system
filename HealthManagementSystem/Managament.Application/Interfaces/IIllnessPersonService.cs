using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface IIllnessPersonService
    {
        Task<List<IllnessPersonListDto>> GetAllPersonIllnessesAsync(int personId);
        Task AddIllnessToPersonAsync(IllnessPersonDto request);
        Task EditIllnessToPersonAsync(int illnessPersonId, IllnessPersonEditDto request);
    }
}
