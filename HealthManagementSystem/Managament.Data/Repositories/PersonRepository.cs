using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly HealthManagementDbContext _context;
        public PersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddPersonAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetAllPersonsAsync()
        {
            var personList = await _context.Persons
                .Include(x => x.Role)
                .Include(x => x.PhoneNumber)
                    .ThenInclude(y => y.PhoneNumberCountryCode)
                .Include(x => x.Address)
                    .ThenInclude(y => y.Country)
                .Include(x => x.Address)
                    .ThenInclude(y => y.City)
                .ToListAsync();

            return personList;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var person = await _context.Persons.FindAsync(id) ??
               throw new Exception($"Person with ID {id} not found.");

            return person;
        }

        public async Task EditPersonAsync(Person person)
        {
            _context.Persons.Attach(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int personId)
        {
            var deletePerson = await GetPersonByIdAsync(personId);
            _ = _context.Persons.Remove(deletePerson) ?? throw new Exception($"Person with ID {personId} was not deleted.");
            await _context.SaveChangesAsync();
        }
    }
}
