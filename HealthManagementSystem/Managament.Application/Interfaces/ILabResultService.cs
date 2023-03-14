using Management.Application.Dto;

namespace Management.Application.Interfaces
{
    public interface ILabResultService
    {
        Task AddLabResultAsync(LabResultDto request);
        Task ChangeLabResultStatusAsync(int labResultId, int statusId);
        Task<List<LabResultListDto>> GetLabResultsForPerson(int personId);
        Task AddDocumentToLabResult(int labResultId, List<DocumentDto> request);
        Task DeleteLabResultAsync(int labResultId);
    }
}
