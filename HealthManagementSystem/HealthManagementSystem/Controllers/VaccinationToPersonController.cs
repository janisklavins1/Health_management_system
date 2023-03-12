using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationToPersonController : ControllerBase
    {
        private readonly IVaccinationPersonService _vaccinationPersonService;

        public VaccinationToPersonController(IVaccinationPersonService vaccinationPersonService)
        {
            _vaccinationPersonService = vaccinationPersonService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<VaccinationPerson>> AddVaccinationToPerson(VaccinationPersonDto request)
        {
            try
            {
                await _vaccinationPersonService.AddVaccinationToPersonAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<List<VaccinationPersonListDto>>> GetVaccinationForPerson(int personId)
        {
            try
            {
                return Ok(await _vaccinationPersonService.GetAllPersonVaccinationsAsync(personId));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{vaccinationPersonId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditVaccinationForPerson(int vaccinationPersonId, VaccinationPersonEditDto request)
        {
            try
            {
                await _vaccinationPersonService.EditVaccinationToPersonAsync(vaccinationPersonId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
