using Management.Application.Dto;
using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class LabResultRepository : ILabResultRepository
    {
        private readonly HealthManagementDbContext _context;

        public LabResultRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddDocumentToLabResult(LabResult labResult)
        {
            _ = _context.LabResults.Attach(labResult)
                ?? throw new Exception($"Couldn't add new Document with ID {labResult.Documents.Last().DocumentId} .");
            await _context.SaveChangesAsync();
        }

        public async Task AddLabResultAsync(LabResult request)
        {
            await _context.LabResults.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLabResultAsync(int labResultId)
        {
            var labResult = await GetLabResultAsync(labResultId);
            _ = _context.LabResults.Remove(labResult) ?? throw new Exception($"Couldn't delete LabResult with ID {labResult.LabResultId} ."); ;
            await _context.SaveChangesAsync();
        }

        public async Task<LabResult> GetLabResultAsync(int labResultId)
        {
            var labResultFound = await _context.LabResults.FindAsync(labResultId);
            return labResultFound ?? throw new Exception($"LabResult with Date {labResultId} not found.");
        }

        public async Task<List<LabResultListDto>> GetLabResultsForPersonAsync(int personId)
        {
            var labResultList = await _context.LabResults
                .Include(x => x.Documents)
                .Where(x => x.PersonId == personId)
                .Select(x => new LabResultListDto()
                {
                    LabResultId = x.LabResultId,
                    Date = x.Date,
                    Document = x.Documents
                })
            .ToListAsync();

            if (labResultList.Count <= 0)
            {
                throw new Exception($"LabResults for person with Id {personId} not found.");
            }

            return labResultList;
        }
    }
}
