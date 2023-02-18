using HealthManagementSystem.Dto;
using Management.Application.Interfaces;
using Management.Data.Models;
using Management.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Country> AddIngredient(IngredientDto request)
        {
            var newIngredient = new Ingredient()
            {
                Name = request.Name
            };

            _ingredientService.AddIngredient(newIngredient);

            return Ok(newIngredient.IngredientId);
        }
    }
}
