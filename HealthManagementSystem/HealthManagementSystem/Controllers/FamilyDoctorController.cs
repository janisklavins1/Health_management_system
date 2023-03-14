using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyDoctorController : ControllerBase
    {
        private readonly IFamilyDoctorService _familyDoctorService;

        public FamilyDoctorController(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService = familyDoctorService;
        }

        [HttpGet("{familyDoctorId}")]
        public async Task<ActionResult<FamilyDoctor>> GetFamilyDoctorById(int familyDoctorId)
        {
            try
            {
                return Ok(await _familyDoctorService.GetFamilyDoctorByIdAsync(familyDoctorId));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FamilyDoctor>> AddFamilyDoctor(FamilyDoctorDto request)
        {
            try
            {
                await _familyDoctorService.AddFamilyDoctorAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{familyDoctorId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FamilyDoctor>> EditFamilyDoctor(int familyDoctorId, FamilyDoctorEditDto request)
        {
            try
            {
                await _familyDoctorService.EditFamilyDoctorAsync(familyDoctorId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
