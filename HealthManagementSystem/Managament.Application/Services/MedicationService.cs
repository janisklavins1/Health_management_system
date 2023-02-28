using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }
        public void AddMedication(Medication medication)
        {

            _medicationRepository.AddMedication(medication);
        }

        public async Task<ICollection<Medication>> GetAllMedicationsAsync()
        {
            return await _medicationRepository.GetAllMedicationsAsync();
        }

        public async Task<Medication> GetMedication(int id)
        {
            return await _medicationRepository.GetMedication(id);
        }

        public async Task EditMedicationAsync(Medication medication)
        {
            await _medicationRepository.EditMedicationAsync(medication);
        }
    }
}
