using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class PhoneNumberCountryCodeRepository : IPhoneNumberCountryCodeRepository
    {
        private readonly HealthManagementDbContext _context;
        public PhoneNumberCountryCodeRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task<PhoneNumberCountryCode> GetPhoneNumberCountryCodeByCodeAsync(string phoneNumberCode)
        {
            return await _context.PhoneNumberCountryCodes.FirstAsync(x => x.Code == phoneNumberCode);
        }
    }
}
