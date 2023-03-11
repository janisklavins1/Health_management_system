using HealthManagementSystem.Dto;
using Management.Application.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
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
        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _personService.GetAllPersonsAsync();
        }

        [HttpGet("{personId}")]
        public async Task<Person> GetPersonById(int personId)
        {
            return await _personService.GetPersonByIdAsync(personId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Person>> AddPerson(PersonDto request)
        {
            await _personService.AddPersonAsync(request);

            return Ok(request.Name);
        }

        [HttpPut("{personId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> EditPerson(int personId, PersonEditDto request)
        {
            await _personService.EditPersonAsync(personId, request);

            return Ok(request);
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePerson(int personId)
        {
            await _personService.DeletePersonAsync(personId);

            return Ok(personId);
        }
    }
}
