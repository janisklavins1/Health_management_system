using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task AddAddressAsync(Address address)
        {
            await _addressRepository.AddAddressAsync(address);
        }
    }
}
