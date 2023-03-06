﻿using HealthManagementSystem.Dto;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Person>> AddPerson(PersonDto request)
        {
            await _personService.AddPersonAsync(request);

            return Ok(request.Name);
        }
    }
}
