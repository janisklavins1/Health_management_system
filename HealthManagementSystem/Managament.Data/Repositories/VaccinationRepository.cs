using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly HealthManagementDbContext _context;

        public VaccinationRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Vaccination> GetVaccinationByIdAsync(int id)
        {
            var vaccination = await _context.Vaccinations
                .FirstAsync(x => x.VaccinationId == id);


            return vaccination ?? throw new Exception($"Vaccination with Id {id} not found.");
        }
    }
}
