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

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            await _ingredientRepository.AddIngredientAsync(ingredient);
        }

        public async Task<ICollection<Ingredient>> GetAllIngredientsAsync()
        {
            return await _ingredientRepository.GetAllIngredientsAsync();
        }

        public async Task<Ingredient> GetIngredientByNameAsync(string name)
        {
            return await _ingredientRepository.GetIngredientByNameAsync(name);
        }
    }
}
