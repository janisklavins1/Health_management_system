using HealthManagementSystem.Dto;
using Management.Application.Dto;
using Management.Application.Enums;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IPhoneNumberCountryCodeRepository _phoneNumberCountryCodeRepository;
        private readonly IRoleRepository _roleRepository;

        public PersonService(
            IPersonRepository personService,
            ICountryRepository countryRepository,
            ICityRepository cityRepository,
            IPhoneNumberCountryCodeRepository phoneNumberCountryCodeRepository,
            IRoleRepository roleRepository)
        {
            _personRepository = personService;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _phoneNumberCountryCodeRepository = phoneNumberCountryCodeRepository;
            _roleRepository = roleRepository;
        }

        public async Task AddPersonAsync(PersonDto request)
        {
            var country = await _countryRepository.GetCountryByNameAsync(request.Country);
            var city = await _cityRepository.GetCityByNameAsync(request.City);
            var phoneNumberCode = await _phoneNumberCountryCodeRepository.GetPhoneNumberCountryCodeByCodeAsync(request.PhoneNumberCountryCode);
            var role = await _roleRepository.GetRoleByIdAsync((int)RoleEnum.Patient);

            var person = new Person()
            {
                Name = request.Name,
                Surname = request.Surname,
                Gender = request.Gender,
                BirthDate = request.BirthDate,
                Address = new Address()
                {
                    HouseAddress = request.HouseAddress,
                    PostIndex = request.PostIndex,
                    City = city,
                    Country = country
                },
                PhoneNumber = new PhoneNumber()
                {
                    Number = request.PhoneNumber,
                    PhoneNumberCountryCode = phoneNumberCode
                },
                Role = role
            };

            await _personRepository.AddPersonAsync(person);
        }

        public async Task DeletePersonAsync(int personId)
        {
            await _personRepository.DeletePersonAsync(personId);
        }

        public async Task EditPersonAsync(int personId, PersonEditDto request)
        {
            var person = await _personRepository.GetPersonByIdAsync(personId);

            var country = await _countryRepository.GetCountryByNameAsync(request.Country);
            var city = await _cityRepository.GetCityByNameAsync(request.City);
            var phoneNumberCode = await _phoneNumberCountryCodeRepository.GetPhoneNumberCountryCodeByCodeAsync(request.PhoneNumberCountryCode);

            person.Name = request.Name;
            person.Surname = request.Surname;
            person.Address = new Address()
            {
                HouseAddress = request.HouseAddress,
                PostIndex = request.PostIndex,
                City = city,
                Country = country
            };
            person.PhoneNumber = new PhoneNumber()
            {
                Number = request.PhoneNumber,
                PhoneNumberCountryCode = phoneNumberCode
            };

            await _personRepository.EditPersonAsync(person);
        }

        public async Task<ICollection<Person>> GetAllPersonsAsync()
        {
            return await _personRepository.GetAllPersonsAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }
    }
}
