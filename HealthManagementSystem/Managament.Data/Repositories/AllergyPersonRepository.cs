using Management.Application.Dto;
using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class AllergyPersonRepository : IAllergyPersonRepository
    {
        private readonly HealthManagementDbContext _context;
        public AllergyPersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAllergyToPersonAsync(AllergyPerson allergyPerson)
        {
            _ = await _context.AllergiesPerson.AddAsync(allergyPerson) ??
                throw new Exception($"Couldn't add Allergy to Person with ID {allergyPerson.PersonId}.");

            await _context.SaveChangesAsync();
        }

        public async Task EditAllergyToPersonAsync(AllergyPerson allergyPerson)
        {
            _ = _context.AllergiesPerson.Attach(allergyPerson)
                ?? throw new Exception($"Couldn't edit Allergy with Persons ID {allergyPerson.PersonId} .");
            await _context.SaveChangesAsync();
        }

        public async Task<List<AllergyPersonListDto>> GetAllPersonAllergiesAsync(int personId)
        {
            var allergiesPerson = await _context.AllergiesPerson
                .Include(x => x.Allergy)
                    .ThenInclude(o => o.TypeOfAllergies)
                .Where(x => x.PersonId == personId)
                .Select(x => new AllergyPersonListDto()
                {
                    AllergyPersonId = x.AllergyPersonId,
                    Allergy = x.Allergy,
                    DateDiscovered = x.DateDiscovered
                })
                .ToListAsync();

            if (allergiesPerson.Count <= 0)
            {
                throw new Exception($"Allergy used by person with Id {personId} not found.");
            }

            return allergiesPerson;
        }

        public async Task<AllergyPerson> GetAllergiesPersonByIdAsync(int allergyPersonId)
        {
            var allergyPerson = await _context.AllergiesPerson.FindAsync(allergyPersonId) ??
                 throw new Exception($"MedicationPerson with Id {allergyPersonId} not found.");

            return allergyPerson;
        }
    }
}
