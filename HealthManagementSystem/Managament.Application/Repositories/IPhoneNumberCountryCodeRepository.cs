using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IPhoneNumberCountryCodeRepository
    {
        Task<PhoneNumberCountryCode> GetPhoneNumberCountryCodeByCodeAsync(string phoneNumberCode);
    }
}
