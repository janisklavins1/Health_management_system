using HealthManagementSystem.Dto;
using Management.Application.Dto;
using Management.Domain.Models;

namespace Management.Application.Interfaces
{
    public interface IPersonService
    {
        Task AddPersonAsync(PersonDto person);
        Task<ICollection<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(int personId);
        Task EditPersonAsync(int personId, PersonEditDto person);
        Task DeletePersonAsync(int personId);
    }
}
