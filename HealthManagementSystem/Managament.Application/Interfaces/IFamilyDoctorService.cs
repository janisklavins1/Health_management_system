using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Interfaces
{
    public interface IFamilyDoctorService
    {
        Task AddFamilyDoctorAsync(FamilyDoctorDto familyDoctor);
        Task<FamilyDoctor> GetFamilyDoctorByIdAsync(int familyDoctorId);
        Task EditFamilyDoctorAsync(int familyDoctorId, FamilyDoctorEditDto familyDoctor);
    }
}
