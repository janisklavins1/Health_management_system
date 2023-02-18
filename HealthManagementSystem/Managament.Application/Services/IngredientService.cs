using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;

namespace Management.Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public void AddIngredient(Ingredient ingredient)
        {
            _ingredientRepository.AddIngredient(ingredient);
        }

        public ICollection<Ingredient> GetAllIngredients()
        {
            throw new NotImplementedException();
        }
    }
}
