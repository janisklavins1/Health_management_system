using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;

namespace Management.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HealthManagementDbContext _context;
        public AddressRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAddressAsync(Address address)
        {
            _ = await _context.Addresses.AddAsync(address) ??
                throw new Exception($"Couldn't add Address with ID {address.Id}.");

            await _context.SaveChangesAsync();
        }
    }
}
