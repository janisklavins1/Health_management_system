using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HealthManagementDbContext _context;
        public RoleRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FirstAsync(x => x.RoleId == roleId) ??
                 throw new Exception($"Role with Id {roleId} not found.");
        }
    }
}
