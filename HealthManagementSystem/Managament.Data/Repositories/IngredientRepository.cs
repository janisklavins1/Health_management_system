using Management.Application.Repositories;
using Management.Data.Context;
using Management.Domain.Models;

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

        public ICollection<Ingredient> GetAllIngredients()
        {
           return  _context.Ingredients.ToList();
        }
    }
}
