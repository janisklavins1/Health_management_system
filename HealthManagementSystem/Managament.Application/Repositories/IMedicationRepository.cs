using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IMedicationRepository
    {
        Medication GetMedication(int id);
        void AddMedication(Medication medication);
    }
}
