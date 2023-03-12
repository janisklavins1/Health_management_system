using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class VaccinationPersonService : IVaccinationPersonService
    {
        private readonly IVaccinationPersonRepository _vaccinationPersonRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IVaccinationRepository _vaccinationRepository;
        private readonly IMedicalPracticeRepository _medicalPracticeRepository;

        public VaccinationPersonService(
            IVaccinationPersonRepository vaccinationPersonRepository,
            IPersonRepository personRepository,
            IVaccinationRepository vaccinationRepository,
            IMedicalPracticeRepository medicalPracticeRepository)
        {
            _vaccinationPersonRepository = vaccinationPersonRepository;
            _personRepository = personRepository;
            _vaccinationRepository = vaccinationRepository;
            _medicalPracticeRepository = medicalPracticeRepository;
        }

        public async Task AddVaccinationToPersonAsync(VaccinationPersonDto request)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);
            var vaccination = await _vaccinationRepository.GetVaccinationByIdAsync(request.VaccinationId);
            var medicalPractice = await _medicalPracticeRepository.GetMedicalPracticeByIdAsync(request.MedicalPracticeId);

            var vaccinationPerson = new VaccinationPerson()
            {
                Vaccination = vaccination,
                Person = person,
                StartingDate = request.StartDate,
                EndingDate = request.EndDate,
                MedicalPractice = medicalPractice
            };

            await _vaccinationPersonRepository.AddVaccinationToPersonAsync(vaccinationPerson);
        }

        public async Task EditVaccinationToPersonAsync(int vaccinationPersonId, VaccinationPersonEditDto request)
        {
            var vaccination = await _vaccinationRepository.GetVaccinationByIdAsync(request.VaccinationId);
            var medicalPractice = await _medicalPracticeRepository.GetMedicalPracticeByIdAsync(request.MedicalPracticeId);
            var vaccinationPerson = await _vaccinationPersonRepository.GetVaccinationsPersonByIdAsync(vaccinationPersonId);
            vaccinationPerson.Vaccination = vaccination;
            vaccinationPerson.MedicalPractice = medicalPractice;
            vaccinationPerson.StartingDate = request.StartDate;
            vaccinationPerson.EndingDate = request.EndDate;

            await _vaccinationPersonRepository.EditVaccinationToPersonAsync(vaccinationPerson);
        }

        public async Task<List<VaccinationPersonListDto>> GetAllPersonVaccinationsAsync(int personId)
        {
            return await _vaccinationPersonRepository.GetAllPersonVaccinationsAsync(personId);
        }
    }
}
