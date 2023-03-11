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

        public async Task<List<MedicationPerson>> GetAllPersonMedicationsAsync(int personId)
        {
            var medicationPerson = await _context.MedicationPersons
                .Include(x => x.Person)
                    .ThenInclude(o => o.Role)
                .Include(x => x.Person)
                    .ThenInclude(o => o.PhoneNumber)
                        .ThenInclude(y => y.PhoneNumberCountryCode)
                .Include(x => x.Person)
                    .ThenInclude(o => o.Address)
                        .ThenInclude(y => y.Country)
                .Include(x => x.Person)
                    .ThenInclude(o => o.Address)
                        .ThenInclude(y => y.City)
                .Include(x => x.Medication)
                    .ThenInclude(o => o.Ingredients)
                        .ThenInclude(y => y.Name)
                .Where(x => x.PersonId == personId)
                .ToListAsync() ?? throw new Exception($"Medication used by person with {personId} not found.");

            return medicationPerson;
        }

        public async Task RemoveMedicationFromPersonAsync(MedicationPerson medicationPerson)
        {
            _ = _context.MedicationPersons.Remove(medicationPerson) ??
                throw new Exception($"Medication used by person with {medicationPerson.PersonId} was not deleted.");

            await _context.SaveChangesAsync();
        }
    }
}
