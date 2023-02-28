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
    public class AddressRepository : IAddressRepository
    {
        private readonly HealthManagementDbContext _context;
        public AddressRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }
    }
}
