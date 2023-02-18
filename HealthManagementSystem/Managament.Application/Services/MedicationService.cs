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
            throw new NotImplementedException();
        }

        public Medication GetMedication(int id)
        {
            throw new NotImplementedException();
        }
    }
}
