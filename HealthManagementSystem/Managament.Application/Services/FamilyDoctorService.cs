using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class FamilyDoctorService : IFamilyDoctorService
    {
        private readonly IFamilyDoctorRepository _familyDoctorRepository;
        private readonly IMedicalPracticeRepository _medicalPracticeRepository;
        private readonly IPersonRepository _personRepository;

        public FamilyDoctorService(
            IFamilyDoctorRepository familyDoctorRepository,
            IMedicalPracticeRepository medicalPracticeRepository,
            IPersonRepository personRepository)
        {
            _familyDoctorRepository = familyDoctorRepository;
            _medicalPracticeRepository = medicalPracticeRepository;
            _personRepository = personRepository;
        }

        public async Task AddFamilyDoctorAsync(FamilyDoctorDto request)
        {
            var medicalPractice = await _medicalPracticeRepository.GetMedicalPracticeByIdAsync(request.MedicalPracticeId);
            var person = await _personRepository.GetPersonByIdAsync(request.PersonId);

            var familyDoctor = new FamilyDoctor()
            {
                MedicalPractice = medicalPractice,
                Person = person,
                PlaceOfEducation = request.PlaceOfEducation,
                Qualification = request.Qualification,
                Status = request.Status,
                JoiningDate = request.JoiningDate
            };

            await _familyDoctorRepository.AddFamilyDoctorAsync(familyDoctor);
        }

        public async Task EditFamilyDoctorAsync(int familyDoctorId, FamilyDoctorEditDto request)
        {
            var familyDoctor = await _familyDoctorRepository.GetFamilyDoctorByIdAsync(familyDoctorId);
            var medicalPractice = await _medicalPracticeRepository.GetMedicalPracticeByIdAsync(request.MedicalPracticeId);

            familyDoctor.MedicalPractice = medicalPractice;
            familyDoctor.Status = request.Status;

            await _familyDoctorRepository.EditFamilyDoctorAsync(familyDoctor);
        }

        public async Task<FamilyDoctor> GetFamilyDoctorByIdAsync(int familyDoctorId)
        {
            return await _familyDoctorRepository.GetFamilyDoctorByIdAsync(familyDoctorId);
        }
    }
}
