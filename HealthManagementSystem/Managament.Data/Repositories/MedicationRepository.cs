using Management.Application.Repositories;
using Management.Data.Context;
using Management.Data.Migrations;
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
        public async Task AddMedicationAsync(Medication medication)
        {
            _ = await _context.Medications.AddAsync(medication) ??
                throw new Exception($"Couldn't add Medication with Name {medication.Name}.");

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Medication>> GetAllMedicationsAsync()
        {
            var medication = await _context.Medications
                .Include(x => x.Ingredients)
                .ToListAsync();

            if (medication.Count <= 0)
            {
                throw new Exception($"Medications not found.");
            }

            return medication;
        }

        public async Task<Medication> GetMedicationAsync(int id)
        {
            var medication = await _context.Medications
                .Include(x => x.Ingredients)
                .FirstAsync(x => x.MedicationId == id);


            return medication ?? throw new Exception($"Medication with ID {id} not found.");
        }

        public async Task EditMedicationAsync(Medication medication)
        {
            _ = _context.Medications.Attach(medication) 
                ?? throw new Exception($"Couldn't edit Medication with ID {medication.MedicationId} not found."); ;
            await _context.SaveChangesAsync();
        }
    }
}
