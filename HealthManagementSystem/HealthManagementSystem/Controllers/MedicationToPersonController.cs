using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationToPersonController : ControllerBase
    {
        private readonly IMedicationPersonService _medicationPersonService;

        public MedicationToPersonController(IMedicationPersonService medicationPersonService)
        {
            _medicationPersonService = medicationPersonService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MedicationPerson>> AddMedicationToPerson(MedicationPersonDto request)
        {
            try
            {
                await _medicationPersonService.AddMedicationToPersonAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<List<MedicationPersonListDto>>> GetMedicationForPerson(int personId)
        {
            try
            {
                return Ok(await _medicationPersonService.GetAllPersonMedicationsAsync(personId));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{medicationPersonId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditMedicationForPerson(int medicationPersonId, MedicationPersonEditDto request)
        {
            try
            {
                await _medicationPersonService.EditMedicationToPersonAsync(medicationPersonId, request);
                return Ok(request);
            }
            catch (Exception error) 
            {
                return BadRequest(error);
            }
        }
    }
}
