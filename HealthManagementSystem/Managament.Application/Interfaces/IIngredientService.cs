using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IIngredientService
    {
        Task<ICollection<Ingredient>> GetAllIngredientsAsync();
        void AddIngredient(Ingredient ingredient);

        Ingredient GetIngredientByName(string name);
    }
}
