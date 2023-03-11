using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IFamilyDoctorRepository
    {
        Task AddFamilyDoctorAsync(FamilyDoctor familyDoctor);
        Task<FamilyDoctor> GetFamilyDoctorByIdAsync(int familyDoctorId);
        Task EditFamilyDoctorAsync(FamilyDoctor familyDoctor);
    }
}
