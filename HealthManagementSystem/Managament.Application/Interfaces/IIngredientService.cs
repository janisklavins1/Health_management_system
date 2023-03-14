using Management.Domain.Models;

namespace Management.Application.Interfaces
{
    public interface IIngredientService
    {
        Task<ICollection<Ingredient>> GetAllIngredientsAsync();
        Task AddIngredientAsync(Ingredient ingredient);

        Task<Ingredient> GetIngredientByNameAsync(string name);
    }
}
