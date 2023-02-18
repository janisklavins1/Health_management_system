using Management.Domain.Models;

namespace Management.Application.Repositories
{
    public interface IIngredientRepository
    {
        ICollection<Ingredient> GetAllIngredients();
        void AddIngredient(Ingredient ingredient);
    }
}
