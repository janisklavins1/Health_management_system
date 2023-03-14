using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface ILabResultStatusRepository
    {
        Task<LabResultStatus> GetLabResultStatusByIdAsync(int id);
    }
}
