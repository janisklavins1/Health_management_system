using Management.Application.Repositories;
using Management.Data.Context;
using Management.Data.Migrations;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly HealthManagementDbContext _context;
        public IngredientRepository(HealthManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            _ = await _context.Ingredients.AddAsync(ingredient) ??
                throw new Exception($"Couldn't add Ingredient with Name {ingredient.Name}.");

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Ingredient>> GetAllIngredientsAsync()
        {
            var ingredient =  await _context.Ingredients.ToListAsync();

            if (ingredient.Count <= 0)
            {
                throw new Exception($"Ingredient not found.");
            }

            return ingredient;
        }

        public async Task<Ingredient> GetIngredientByNameAsync(string name)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(x => x.Name == name) ??
                 throw new Exception($"Ingredient with Name {name} not found.");

            return ingredient;
        }
    }
}
