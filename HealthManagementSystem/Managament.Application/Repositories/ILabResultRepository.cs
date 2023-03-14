using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface ILabResultRepository
    {
        Task AddLabResultAsync(LabResult request);
        Task<LabResult> GetLabResultAsync(int labResultId);
        Task<List<LabResultListDto>> GetLabResultsForPersonAsync(int personId);
        Task AddDocumentToLabResultAsync(LabResult labResult);
        Task DeleteLabResultAsync(int labResultId);
    }
}
