using Management.Application.Dto;
using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class IllnessPersonRepository : IIllnessPersonRepository
    {
        private readonly HealthManagementDbContext _context;

        public IllnessPersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddIllnessToPersonAsync(IllnessPerson illnessPerson)
        {
            _ = await _context.IllnessesPersons.AddAsync(illnessPerson) ??
                throw new Exception($"Couldn't add Illness to Person with ID {illnessPerson.PersonId}.");

            await _context.SaveChangesAsync();
        }

        public async Task EditIllnessToPersonAsync(IllnessPerson illnessPerson)
        {
            _ = _context.IllnessesPersons.Attach(illnessPerson)
                ?? throw new Exception($"Couldn't edit Illness with Persons ID {illnessPerson.PersonId} .");
            await _context.SaveChangesAsync();
        }

        public async Task<List<IllnessPersonListDto>> GetAllPersonIllnessesAsync(int personId)
        {
            var illnessPerson = await _context.IllnessesPersons
                .Include(x => x.Illness)
                .Where(x => x.PersonId == personId)
                .Select(x => new IllnessPersonListDto()
                {
                    IllnessPersonId = x.IllnessPersonId,
                    Illness = x.Illness,
                    DateDiscovered = x.DateDiscovered,
                    Status = x.Status,
                    Prohibitions = x.Prohibitions
                })
                .ToListAsync();

            if (illnessPerson.Count <= 0)
            {
                throw new Exception($"Illness used by person with Id {personId} not found.");
            }

            return illnessPerson;
        }

        public async Task<IllnessPerson> GetIllnessesPersonByIdAsync(int illnessPersonId)
        {
            var illnessPerson = await _context.IllnessesPersons.FindAsync(illnessPersonId) ??
                 throw new Exception($"IllnessPerson with Id {illnessPersonId} not found.");

            return illnessPerson;
        }
    }
}
