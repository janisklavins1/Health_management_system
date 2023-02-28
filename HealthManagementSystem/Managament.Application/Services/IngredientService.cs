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

        public async Task<ICollection<Ingredient>> GetAllIngredientsAsync()
        {
            return await _ingredientRepository.GetAllIngredientsAsync();
        }

        public Ingredient GetIngredientByName(string name)
        {
            return _ingredientRepository.GetIngredientByName(name);
        }
    }
}
