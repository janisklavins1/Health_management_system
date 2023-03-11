using Management.Application.Dto;
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
            var medication = await _medicationRepository.GetMedication(request.MedicationId);
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);

            var medicationPerson = new MedicationPerson()
            {
                Medication = medication,
                Person = person,
                StartingDate = request.StartingDate,
                EndingDate = request.EndingDate
            };

            await _medicationPersonRepository.AddMedicationToPersonAsync(medicationPerson);
        }

        public Task<List<MedicationPerson>> GetAllPersonMedicationsAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMedicationFromPersonAsync(MedicationPerson medicationPerson)
        {
            throw new NotImplementedException();
        }
    }
}
