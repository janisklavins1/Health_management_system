using HealthManagementSystem.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMedicationService _medicationService;

        public MedicationController(IIngredientService ingredientService, IMedicationService medicationService)
        {
            _ingredientService = ingredientService;
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Medication>> GetAllMedicationsAsync()
        {
            return await _medicationService.GetAllMedicationsAsync();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Medication> AddMedication(MedicationDto request)
        {
            var ingredientsCollection = new List<Ingredient>();

            foreach (var item in request.Ingredients)
            {
                var foundIngredient = _ingredientService.GetIngredientByName(item.Name);

                if (foundIngredient != null)
                {
                    ingredientsCollection.Add(foundIngredient);
                }
                else
                {
                    ingredientsCollection.Add(new Ingredient() { Name = item.Name });
                }
            }

            var newMedication = new Medication()
            {
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                Ingredients = ingredientsCollection
            };

            _medicationService.AddMedication(newMedication);

            return Ok(newMedication.MedicationId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Medication>> EditMedication(int id, MedicationDto request)
        {
            var ingredientsCollection = new List<Ingredient>();

            foreach (var item in request.Ingredients)
            {
                var foundIngredient = _ingredientService.GetIngredientByName(item.Name);

                if (foundIngredient != null)
                {
                    ingredientsCollection.Add(foundIngredient);
                }
                else
                {
                    ingredientsCollection.Add(new Ingredient() { Name = item.Name });
                }
            }

            var editMedicine = await _medicationService.GetMedication(id);
            if (editMedicine == null)
            {
                return NotFound();
            }

            //if (id != editMedicine.MedicationId)
            //{
            //    return BadRequest();
            //}
            editMedicine.Name = request.Name;
            editMedicine.Description = request.Description;
            editMedicine.Type = request.Type;
            editMedicine.Ingredients = ingredientsCollection;

            await _medicationService.EditMedicationAsync(editMedicine);

            return NoContent();
        }


        //[HttpGet]
        //public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        //{
        //    return await _ingredientService.GetAllIngredientsAsync();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public ActionResult<Country> AddIngredient(IngredientDto request)
        //{
        //    var newIngredient = new Ingredient()
        //    {
        //        Name = request.Name
        //    };

        //    _ingredientService.AddIngredient(newIngredient);

        //    return Ok(newIngredient.IngredientId);
        //}
    }
}
