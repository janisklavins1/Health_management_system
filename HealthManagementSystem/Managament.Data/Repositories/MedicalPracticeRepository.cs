using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;

namespace Management.Data.Repositories
{
    public class MedicalPracticeRepository : IMedicalPracticeRepository
    {
        private readonly HealthManagementDbContext _context;

        public MedicalPracticeRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalPractice> GetMedicalPracticeByIdAsync(int medicalPracticeId)
        {
            var medicalPractice = await _context.MedicalPractices.FindAsync(medicalPracticeId) ??
               throw new Exception($"{nameof(MedicalPractice)} with ID {medicalPracticeId} not found.");

            return medicalPractice;
        }
    }
}
