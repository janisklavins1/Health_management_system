using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IMedicalPracticeRepository
    {
        Task<MedicalPractice> GetMedicalPracticeByIdAsync(int medicalPracticeId);
    }
}
