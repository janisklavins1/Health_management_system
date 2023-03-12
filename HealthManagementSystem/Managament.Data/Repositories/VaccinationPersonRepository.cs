using Management.Application.Dto;
using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class VaccinationPersonRepository : IVaccinationPersonRepository
    {
        private readonly HealthManagementDbContext _context;

        public VaccinationPersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddVaccinationToPersonAsync(VaccinationPerson vaccinationPerson)
        {
            _ = await _context.VaccinationPersons.AddAsync(vaccinationPerson) ??
                throw new Exception($"Couldn't add Vaccination to Person with ID {vaccinationPerson.PersonId}.");

            await _context.SaveChangesAsync();
        }

        public async Task EditVaccinationToPersonAsync(VaccinationPerson vaccinationPerson)
        {
            _ = _context.VaccinationPersons.Attach(vaccinationPerson)
                ?? throw new Exception($"Couldn't edit Vaccination with Persons ID {vaccinationPerson.PersonId} .");
            await _context.SaveChangesAsync();
        }

        public async Task<List<VaccinationPersonListDto>> GetAllPersonVaccinationsAsync(int personId)
        {
            var vaccinationPerson = await _context.VaccinationPersons
                .Include(x => x.Vaccination)
                .Where(x => x.PersonId == personId)
                .Select(x => new VaccinationPersonListDto()
                {
                    VaccinationPersonId = x.VaccinationPersonId,
                    Vaccination = x.Vaccination,
                    StartDate = x.StartingDate,
                    EndDate = x.EndingDate
                })
                .ToListAsync();

            if (vaccinationPerson.Count <= 0)
            {
                throw new Exception($"Vaccination used by person with Id {personId} not found.");
            }

            return vaccinationPerson;
        }

        public async Task<VaccinationPerson> GetVaccinationsPersonByIdAsync(int vaccinationPersonId)
        {
            var vaccinationPerson = await _context.VaccinationPersons.FindAsync(vaccinationPersonId) ??
                 throw new Exception($"MedicationPerson with Id {vaccinationPersonId} not found.");

            return vaccinationPerson;
        }
    }
}
