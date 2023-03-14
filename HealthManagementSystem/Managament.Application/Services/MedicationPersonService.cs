using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class MedicationPersonService : IMedicationPersonService
    {
        private readonly IMedicationPersonRepository _medicationPersonRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMedicationRepository _medicationRepository;

        public MedicationPersonService(
            IMedicationPersonRepository medicationPersonRepository,
            IPersonRepository personRepository,
            IMedicationRepository medicationRepository)
        {
            _medicationPersonRepository = medicationPersonRepository;
            _personRepository = personRepository;
            _medicationRepository = medicationRepository;
        }

        public async Task AddMedicationToPersonAsync(MedicationPersonDto request)
        {
            var medication = await _medicationRepository.GetMedicationAsync(request.MedicationId);
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);

            var medicationPerson = new MedicationPerson()
            {
                Medication = medication,
                Person = person,
                StartingDate = request.StartingDate,
                EndingDate = request.EndingDate,
                IsActive = request.IsActive
            };

            await _medicationPersonRepository.AddMedicationToPersonAsync(medicationPerson);
        }

        public async Task EditMedicationToPersonAsync(int medicationPersonId, MedicationPersonEditDto request)
        {
            var medicationPerson = await _medicationPersonRepository.GetMedicationPersonByIdAsync(medicationPersonId);
            var medication = await _medicationRepository.GetMedicationAsync(request.MedicationId);

            medicationPerson.Medication = medication;
            medicationPerson.EndingDate = request.EndingDate;
            medicationPerson.IsActive = request.IsActive;

            await _medicationPersonRepository.EditMedicationToPersonAsync(medicationPerson);
        }

        public async Task<List<MedicationPersonListDto>> GetAllPersonMedicationsAsync(int personId)
        {
            return await _medicationPersonRepository.GetAllPersonMedicationsAsync(personId);
        }
    }
}
