using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface ILabResultStatusLabResultsRepository
    {
        Task AddLabResultsStatusToLabResultAsync(LabResultStatusLabResult labResultStatusLabResult);
        Task<ICollection<LabResultStatusDto>> GetLabResultStatusesAsync(int labResultId);
    }
}
