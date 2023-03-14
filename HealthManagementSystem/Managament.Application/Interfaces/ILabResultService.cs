using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface ILabResultService
    {
        Task AddLabResultAsync(LabResultDto request);
        Task ChangeLabResultStatusAsync(int labResultId, int statusId);
        Task<List<LabResultListDto>> GetLabResultsForPersonAsync(int personId);
        Task AddDocumentToLabResultAsync(int labResultId, List<DocumentDto> request);
        Task DeleteLabResultAsync(int labResultId);
    }
}
