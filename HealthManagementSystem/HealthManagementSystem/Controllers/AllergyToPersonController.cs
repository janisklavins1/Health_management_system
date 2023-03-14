using HealthManagementSystem.Dto;
using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyToPersonController : ControllerBase
    {
        private readonly IAllergyPersonService _allergyPersonService;

        public AllergyToPersonController(IAllergyPersonService allergyPersonService)
        {
            _allergyPersonService = allergyPersonService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<AllergyPerson>> AddAllergyToPerson(AllergyPersonDto request)
        {
            try
            {
                await _allergyPersonService.AddAllergyToPersonAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AllergyPersonListDto>>> GetAllergyForPerson(int personId)
        {
            try
            {
                return Ok(await _allergyPersonService.GetAllPersonAllergiesAsync(personId));
            }
            catch (Exception error)
            {
                return NotFound(error);
            }
        }

        [HttpPut("{allergyPersonId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditAllergyForPerson(int allergyPersonId, AllergyPersonEditDto request)
        {
            try
            {
                await _allergyPersonService.EditAllergyToPersonAsync(allergyPersonId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
