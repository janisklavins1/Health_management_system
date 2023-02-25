using HealthManagementSystem.Dto;
using Management.Application.Interfaces;
using Management.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyPersonService _allergyPersonService;

        public AllergyController(IAllergyPersonService allergyPersonService)
        {
            _allergyPersonService = allergyPersonService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<AllergyPerson>> AddAllergyToPerson(AllergyPersonDto request)
        {
            //if (request.Allergy == null || request.Person == null)
            //{
            //    return NotFound();
            //}

            //var allergy = new Allergy()
            //{
            //    Name = request.Allergy.Name
            //};

            //var person = new Person()
            //{
            //    Name = request.Person.Name,
            //    Surname = request.Person.Surname,
            //    Gender = request.Person.Gender,
            //    BirthDate = request.Person.BirthDate
            //};

            var allergyPerson = new AllergyPerson()
            {
                AllergyId = request.AllergyId,
                PersonId = request.PersonId,
                DateDiscovered = request.DateDiscovered
            };

            await _allergyPersonService.AddAllergyToPerson(allergyPerson);

            return Ok(allergyPerson.PersonId);
        }
    }
}
