using Management.Domain.Models;
using Microsoft.AspNetCore.DataProtection;

namespace Management.Application.Helpers
{
    public class Encryption
    {
        private readonly IDataProtector _dataProtector;

        public Encryption(IDataProtector dataProtector)
        {
            _dataProtector = dataProtector;
        }

        public Person Protect(Person request)
        {
            if (request.PersonId == 0) // New Person
            {
                request.Address.HouseAddress = _dataProtector.Protect(request.Address.HouseAddress);
                request.Address.PostIndex = _dataProtector.Protect(request.Address.PostIndex);

                request.PhoneNumber.Number = _dataProtector.Protect(request.PhoneNumber.Number);

                return new Person()
                {
                    Name = _dataProtector.Protect(request.Name),
                    Surname = _dataProtector.Protect(request.Surname),
                    Gender = _dataProtector.Protect(request.Gender),
                    BirthDate = request.BirthDate,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    Role = request.Role
                };
            }
            else // Edited Person
            {
                request.Name = _dataProtector.Protect(request.Name);
                request.Surname = _dataProtector.Protect(request.Surname);
                request.Address.HouseAddress = _dataProtector.Protect(request.Address.HouseAddress);
                request.Address.PostIndex = _dataProtector.Protect(request.Address.PostIndex);
                request.PhoneNumber.Number = _dataProtector.Protect(request.PhoneNumber.Number);

                return request;
            }
        }
    }
}
