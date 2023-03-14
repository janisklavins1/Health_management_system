using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class LabResultStatusRepository : ILabResultStatusRepository
    {
        private readonly HealthManagementDbContext _context;

        public LabResultStatusRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<LabResultStatus> GetLabResultStatusByIdAsync(int id)
        {
            var labResultStatus = await _context.LabResultStatuses
                .FirstAsync(x => x.LabResultStatusId == id);


            return labResultStatus ?? throw new Exception($"Lab result status with ID {id} not found.");
        }
    }
}
