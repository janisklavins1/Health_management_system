using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IPersonRepository
    {
        Task AddPersonAsync(Person person);
        Task<ICollection<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(int id);
    }
}
