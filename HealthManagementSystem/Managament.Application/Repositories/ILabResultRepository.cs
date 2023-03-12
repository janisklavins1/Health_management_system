using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface ILabResultRepository
    {
        Task AddLabResultAsync(LabResult request);
    }
}
