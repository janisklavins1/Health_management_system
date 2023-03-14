using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IIngredientRepository
    {
        Task<ICollection<Ingredient>> GetAllIngredientsAsync();
        Task AddIngredientAsync(Ingredient ingredient);
        Task<Ingredient> GetIngredientByNameAsync(string name);
    }
}
