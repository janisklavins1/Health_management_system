﻿using Management.Data.Models;

namespace Management.Application.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
    }
}