using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;

namespace Management.Data.Repositories
{
    public class LabResultRepository : ILabResultRepository
    {
        private readonly HealthManagementDbContext _context;

        public LabResultRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddLabResultAsync(LabResult request)
        {
            await _context.LabResults.AddAsync(request);
            await _context.SaveChangesAsync();
        }
    }
}
