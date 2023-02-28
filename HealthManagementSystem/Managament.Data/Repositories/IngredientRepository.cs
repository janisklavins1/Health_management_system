using Management.Application.Repositories;
using Management.Data.Context;
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

        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        public async Task<ICollection<Ingredient>> GetAllIngredientsAsync()
        {
           return await  _context.Ingredients.ToListAsync();
        }

        public Ingredient GetIngredientByName(string name)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(x => x.Name == name);

            if (ingredient != null)
            {
                return ingredient;
            }

            return null;
        }
    }
}
