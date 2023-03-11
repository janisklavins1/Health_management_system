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
        public async Task<FamilyDoctor> GetFamilyDoctorById(int familyDoctorId)
        {
            return await _familyDoctorService.GetFamilyDoctorByIdAsync(familyDoctorId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FamilyDoctor>> AddFamilyDoctor(FamilyDoctorDto request)
        {
            await _familyDoctorService.AddFamilyDoctorAsync(request);

            return Ok(request);
        }

        [HttpPut("{familyDoctorId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FamilyDoctor>> EditFamilyDoctor(int familyDoctorId, FamilyDoctorEditDto request)
        {
            await _familyDoctorService.EditFamilyDoctorAsync(familyDoctorId, request);

            return Ok(request);
        }
    }
}
