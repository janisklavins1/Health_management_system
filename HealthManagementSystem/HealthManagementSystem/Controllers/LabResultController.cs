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

        [HttpPost("AddNewLabResult")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LabResult>> AddNewLabResult(LabResultDto request)
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

        [HttpPost("AddDocumentToLabResult")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LabResult>> AddDocumentToLabResult(int labResultId, List<DocumentDto> request)
        {
            try
            {
                await _labResultService.AddDocumentToLabResultAsync(labResultId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("ChangeLabResultStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LabResult>> ChangeLabResultStatus(int labResultId, int statusId)
        {
            try
            {
                await _labResultService.ChangeLabResultStatusAsync(labResultId, statusId);
                return Ok(labResultId);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<List<LabResultListDto>>> GetAllLabResultsForPerson(int personId)
        {
            try
            {
                return Ok(await _labResultService.GetLabResultsForPersonAsync(personId));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{labResultId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteLabResult(int labResultId)
        {
            try
            {
                await _labResultService.DeleteLabResultAsync(labResultId);
                return Ok(labResultId);
            }
            catch (Exception)
            {
                return BadRequest(labResultId);
            }
        }
    }
}
