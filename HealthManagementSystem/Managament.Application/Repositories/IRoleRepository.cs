using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(int roleId);
    }
}
