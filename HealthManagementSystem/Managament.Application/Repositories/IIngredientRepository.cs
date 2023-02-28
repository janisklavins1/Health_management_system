using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IIngredientRepository
    {
        Task<ICollection<Ingredient>> GetAllIngredientsAsync();
        void AddIngredient(Ingredient ingredient);
        Ingredient GetIngredientByName(string name);
    }
}
