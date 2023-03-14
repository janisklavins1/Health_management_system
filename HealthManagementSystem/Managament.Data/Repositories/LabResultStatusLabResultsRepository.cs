using Management.Application.Dto;
using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class LabResultStatusLabResultsRepository : ILabResultStatusLabResultsRepository
    {
        private readonly HealthManagementDbContext _context;

        public LabResultStatusLabResultsRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddLabResultsStatusToLabResultAsync(LabResultStatusLabResult labResultStatusLabResult)
        {
            _ = await _context.LabResultStatusLabResults.AddAsync(labResultStatusLabResult) ??
                throw new Exception($"Couldn't add Status to LabResult with ID {labResultStatusLabResult.LabResultStatusId}.");

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<LabResultStatusDto>> GetLabResultStatuses(int labResultId)
        {
            var labResultStatusLabResults = await _context.LabResultStatusLabResults
                    .Include(x => x.LabResultStatus)
                    .Where(x => x.LabResultId == labResultId)
                    .ToListAsync();

            var labResultStatuses = new List<LabResultStatusDto>();
            foreach (var item in labResultStatusLabResults)
            {
                if (item.LabResultStatus is not null)
                {
                    labResultStatuses.Add(new LabResultStatusDto() { Status = item.LabResultStatus.Name, Date = item.Date });
                }
            }

            return labResultStatuses.OrderBy(x => x.Date).ToList();
        }
    }
}
