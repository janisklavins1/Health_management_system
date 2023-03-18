using HealthManagementSystem.Dto;
using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            try
            {
                return Ok(await _personService.GetAllPersonsAsync());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> GetPersonById(int personId)
        {
            try
            {
                return Ok(await _personService.GetPersonByIdAsync(personId));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Person>> AddPerson(PersonDto request)
        {
            try
            {
                await _personService.AddPersonAsync(request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{personId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> EditPerson(int personId, PersonEditDto request)
        {
            try
            {
                await _personService.EditPersonAsync(personId, request);
                return Ok(request);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson(int personId)
        {
            try
            {
                await _personService.DeletePersonAsync(personId);
                return Ok(personId);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
