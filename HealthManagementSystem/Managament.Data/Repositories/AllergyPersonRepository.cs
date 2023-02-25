using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public class AllergyPersonRepository : IAllergyPersonRepository
    {
        private readonly HealthManagementDbContext _context;
        public AllergyPersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAllergyToPerson(AllergyPerson allergyPerson)
        {
            var person = await _context.Persons.FindAsync(allergyPerson.PersonId);
            //var allergy = await _context.

            await _context.AddAsync(allergyPerson);
            await _context.SaveChangesAsync();
        }

        public Task<List<AllergyPerson>> GetAllPersonAllergies(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
