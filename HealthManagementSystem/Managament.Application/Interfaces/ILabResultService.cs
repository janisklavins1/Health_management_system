using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Interfaces
{
    public interface ILabResultService
    {
        Task AddLabResultAsync(LabResultDto request);
    }
}
