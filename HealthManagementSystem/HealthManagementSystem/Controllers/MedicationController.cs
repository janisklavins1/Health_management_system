using HealthManagementSystem.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<List<Medication>>> GetAllMedicationsAsync()
        {
            try
            {
                return Ok(await _medicationService.GetAllMedicationsAsync());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Medication>> AddMedication(MedicationDto request)
        {
            try
            {
                await _medicationService.AddMedicationAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Medication>> EditMedication(int id, MedicationDto request)
        {
            try
            {
                await _medicationService.EditMedicationAsync(id, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
