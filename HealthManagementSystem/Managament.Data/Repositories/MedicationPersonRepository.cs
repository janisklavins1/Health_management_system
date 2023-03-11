using Management.Application.Dto;
using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class MedicationPersonRepository : IMedicationPersonRepository
    {
        private readonly HealthManagementDbContext _context;

        public MedicationPersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddMedicationToPersonAsync(MedicationPerson medicationPerson)
        {
            _ = await _context.MedicationPersons.AddAsync(medicationPerson) ??
                throw new Exception($"Couldn't add Medication to Person with ID {medicationPerson.PersonId}.");

            await _context.SaveChangesAsync();
        }

        public async Task EditMedicationToPersonAsync(MedicationPerson medicationPerson)
        {
            _ = _context.MedicationPersons.Attach(medicationPerson)
                ?? throw new Exception($"Couldn't edit Persons Medication with ID {medicationPerson.PersonId} .");
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicationPersonListDto>> GetAllPersonMedicationsAsync(int personId)
        {
            var medicationPerson = await _context.MedicationPersons
                .Include(x => x.Medication)
                    .ThenInclude(o => o.Ingredients)
                .Where(x => x.PersonId == personId)
                .Select(x => new MedicationPersonListDto() 
                {
                    MedicationPersonId = x.MedicationPersonId,
                    Medication = x.Medication,
                    StartingDate = x.StartingDate,
                    EndingDate = x.EndingDate,
                    IsActive = x.IsActive

                })
                .ToListAsync();

            if (medicationPerson.Count <= 0)
            {
                throw new Exception($"Medication used by person with {personId} not found.");
            }

            return medicationPerson;
        }

        public async Task<MedicationPerson> GetMedicationPersonByIdAsync(int medicationPersonId)
        {
            var medicationPerson = await _context.MedicationPersons.FindAsync(medicationPersonId) ??
                  throw new Exception($"MedicationPerson with Id {medicationPersonId} not found.");

            return medicationPerson;
        }
    }
}
