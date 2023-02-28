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
            var person = await _context.Persons.FindAsync(allergyPerson.PersonId) ??
                throw new Exception($"Person with ID {allergyPerson.PersonId} not found.");

            var allergy = await _context.Allergies.FindAsync(allergyPerson.AllergyId) ??
                throw new Exception($"Allergy with ID {allergyPerson.AllergyId} not found.");


            var allergyPersonObj = new AllergyPerson()
            {
                Allergy = allergy,
                Person = person,
                DateDiscovered = allergyPerson.DateDiscovered
            };

            await _context.AllergiesPerson.AddAsync(allergyPersonObj);
            await _context.SaveChangesAsync();
        }

        public Task<List<AllergyPerson>> GetAllPersonAllergies(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
