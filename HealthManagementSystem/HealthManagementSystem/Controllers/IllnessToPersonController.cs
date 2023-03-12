using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllnessToPersonController : ControllerBase
    {
        private readonly IIllnessPersonService _illnessPersonService;

        public IllnessToPersonController(IIllnessPersonService illnessPersonService)
        {
            _illnessPersonService = illnessPersonService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<IllnessPerson>> AddIllnessToPerson(IllnessPersonDto request)
        {
            try
            {
                await _illnessPersonService.AddIllnessToPersonAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<List<IllnessPersonListDto>>> GetIllnessForPerson(int personId)
        {
            try
            {
                return Ok(await _illnessPersonService.GetAllPersonIllnessesAsync(personId));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{illnessPersonId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditAllergyForPerson(int illnessPersonId, IllnessPersonEditDto request)
        {
            try
            {
                await _illnessPersonService.EditIllnessToPersonAsync(illnessPersonId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
