using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Application.Services;
using Management.Domain.Models;
using Microsoft.AspNetCore.Http;
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
            await _medicationPersonService.AddMedicationToPersonAsync(request);

            return Ok(request);
        }

        //[HttpGet("{personId}")]
        //public async Task<FamilyDoctor> GetFamilyDoctorById(int personId)
        //{

        //}
    }
}
