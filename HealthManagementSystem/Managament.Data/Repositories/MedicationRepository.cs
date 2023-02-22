using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly HealthManagementDbContext _context;
        public MedicationRepository(HealthManagementDbContext context)
        {
            _context = context;
        }
        public void AddMedication(Medication medication)
        {
            _context.Medications.Add(medication);
            _context.SaveChanges();
        }

        public async Task<ICollection<Medication>> GetAllMedicationsAsync()
        {
            var medication = await _context.Medications
                .Include(x => x.Ingredients)
                .ToListAsync();

            return medication;
        }

        public async Task<Medication> GetMedication(int id)
        {
            var medication = await _context.Medications
                .Include(x => x.Ingredients)
                .FirstAsync(x => x.MedicationId == id);


            return medication ?? throw new Exception($"Medication with ID {id} not found.");
        }

        public async Task EditMedicationAsync(Medication medication)
        {
            _context.Medications.Attach(medication);
            await _context.SaveChangesAsync();
        }
    }
}
