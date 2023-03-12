using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabResultController : ControllerBase
    {
        private readonly ILabResultService _labResultService;

        public LabResultController(ILabResultService labResultService)
        {
            _labResultService = labResultService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LabResult>> AddLabResult(LabResultDto request)
        {
            try
            {
                await _labResultService.AddLabResultAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //[HttpGet("{personId}")]
        //public async Task<ActionResult<List<AllergyPersonListDto>>> GetAllergyForPerson(int personId)
        //{
        //    try
        //    {
        //        return Ok(await _allergyPersonService.GetAllPersonAllergiesAsync(personId));
        //    }
        //    catch (Exception error)
        //    {
        //        return BadRequest(error);
        //    }
        //}

        //[HttpPut("{allergyPersonId}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> EditAllergyForPerson(int allergyPersonId, AllergyPersonEditDto request)
        //{
        //    try
        //    {
        //        await _allergyPersonService.EditAllergyToPersonAsync(allergyPersonId, request);
        //        return Ok(request);
        //    }
        //    catch (Exception error)
        //    {
        //        return BadRequest(error);
        //    }
        //}
    }
}
