using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class FamilyDoctorRepository : IFamilyDoctorRepository
    {
        private readonly HealthManagementDbContext _context;

        public FamilyDoctorRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddFamilyDoctorAsync(FamilyDoctor familyDoctor)
        {
            await _context.FamilyDoctors.AddAsync(familyDoctor);
            await _context.SaveChangesAsync();
        }

        public async Task EditFamilyDoctorAsync(FamilyDoctor familyDoctor)
        {
            _ = _context.FamilyDoctors.Attach(familyDoctor) ?? throw new Exception($"Couldn't edit Family Doctor with ID {familyDoctor.FamilyDoctorId} .");
            await _context.SaveChangesAsync();
        }

        public async Task<FamilyDoctor> GetFamilyDoctorByIdAsync(int familyDoctorId)
        {
            var familyDoctor = await _context.FamilyDoctors
                .Include(x => x.MedicalPractice)
                    .ThenInclude(o => o.PhoneNumber)
                    .ThenInclude(o => o.PhoneNumberCountryCode)
                .Include(x => x.MedicalPractice)
                    .ThenInclude(o => o.Address)
                        .ThenInclude(y => y.Country)
                .Include(x => x.MedicalPractice)
                    .ThenInclude(o => o.Address)
                        .ThenInclude(y => y.City)
                .Include(x => x.Person)
                    .ThenInclude(x => x.Role)
                .Include(x => x.Person)
                    .ThenInclude(x => x.PhoneNumber)
                    .ThenInclude(y => y.PhoneNumberCountryCode)
                .Include(x => x.Person)
                    .ThenInclude(x => x.Address)
                    .ThenInclude(y => y.Country)
                .Include(x => x.Person)
                    .ThenInclude(x => x.Address)
                    .ThenInclude(y => y.City)
                .Where(x => x.FamilyDoctorId == familyDoctorId)
                .FirstOrDefaultAsync() ?? throw new Exception($"Person with ID {familyDoctorId} not found.");

            return familyDoctor;
        }
    }
}
