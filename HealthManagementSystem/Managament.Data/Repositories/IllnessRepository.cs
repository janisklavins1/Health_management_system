using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class IllnessRepository : IIllnessRepository
    {
        private readonly HealthManagementDbContext _context;

        public IllnessRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Illness> GetIllnessByIdAsync(int id)
        {
            var illness = await _context.Illnesses
                .FirstAsync(x => x.IllnessId == id);


            return illness ?? throw new Exception($"Illness with Id {id} not found.");
        }
    }
}
