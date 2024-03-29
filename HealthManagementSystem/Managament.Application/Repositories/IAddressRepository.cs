﻿using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IAddressRepository
    {
        Task AddAddressAsync(Address address);
    }
}
