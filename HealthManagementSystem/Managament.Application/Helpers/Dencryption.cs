using Management.Domain.Models;
using Microsoft.AspNetCore.DataProtection;
using System.Net;

namespace Management.Application.Helpers
{
    public class Dencryption
    {
        private readonly IDataProtector _dataProtector;

        public Dencryption(IDataProtector dataProtector)
        {
            _dataProtector = dataProtector;
        }

        public Person UnProtect(Person request)
        {
            request.Name = _dataProtector.Unprotect(request.Name);
            request.Surname = _dataProtector.Unprotect(request.Surname);
            request.Gender = _dataProtector.Unprotect(request.Gender);
            request.Address.HouseAddress = _dataProtector.Unprotect(request.Address.HouseAddress);
            request.Address.PostIndex = _dataProtector.Unprotect(request.Address.PostIndex);
            request.PhoneNumber.Number = _dataProtector.Unprotect(request.PhoneNumber.Number);

            return request;
        }

        public ICollection<Person> UnProtect(ICollection<Person> request)
        {
            var list = new List<Person>();
            foreach (var person in request)
            {
                list.Add(UnProtect(person));
            }
            
            return list;
        }
    }
}
