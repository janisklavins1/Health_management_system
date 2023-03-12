using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly HealthManagementDbContext _context;

        public AllergyRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Allergy> GetAllergyByIdAsync(int id)
        {
            var allergy = await _context.Allergies
                .Include(x => x.TypeOfAllergies)
                .FirstAsync(x => x.AllergyId == id);


            return allergy ?? throw new Exception($"Allergy with Id {id} not found.");
        }
    }
}
