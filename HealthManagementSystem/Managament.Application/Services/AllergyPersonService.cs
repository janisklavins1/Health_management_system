using HealthManagementSystem.Dto;
using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class AllergyPersonService : IAllergyPersonService
    {
        private readonly IAllergyPersonRepository _allergyPersonRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IAllergyRepository _allergyRepository;

        public AllergyPersonService(IAllergyPersonRepository allergyPersonRepository, IPersonRepository personRepository, IAllergyRepository allergyRepository)
        {
            _allergyPersonRepository = allergyPersonRepository;
            _personRepository = personRepository;
            _allergyRepository = allergyRepository;

        }

        public async Task AddAllergyToPersonAsync(AllergyPersonDto request)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);
            var allergy = await _allergyRepository.GetAllergyByIdAsync(request.AllergyId);

            var allergyPerson = new AllergyPerson()
            {
                Person = person,
                Allergy = allergy,
                DateDiscovered = request.DateDiscovered
            };

            await _allergyPersonRepository.AddAllergyToPersonAsync(allergyPerson);
        }

        public async Task EditAllergyToPersonAsync(int allergyPersonId, AllergyPersonEditDto request)
        {
            var allergy = await _allergyRepository.GetAllergyByIdAsync(request.AllergyId);
            var allergyPerson = await _allergyPersonRepository.GetAllergiesPersonByIdAsync(allergyPersonId);
            allergyPerson.Allergy = allergy;
            allergyPerson.DateDiscovered = request.DateDiscovered;

            await _allergyPersonRepository.EditAllergyToPersonAsync(allergyPerson);
        }

        public async Task<List<AllergyPersonListDto>> GetAllPersonAllergiesAsync(int personId)
        {
            return await _allergyPersonRepository.GetAllPersonAllergiesAsync(personId);
        }
    }
}
