using Management.Application.Interfaces;
using Management.Application.Repositories;
using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class AllergyPersonService : IAllergyPersonService
    {
        private readonly IAllergyPersonRepository _allergyPersonRepository;

        public AllergyPersonService(IAllergyPersonRepository allergyPersonRepository)
        {
            _allergyPersonRepository = allergyPersonRepository;
        }

        public async Task AddAllergyToPerson(AllergyPerson allergyPerson)
        {
            await _allergyPersonRepository.AddAllergyToPerson(allergyPerson);
        }

        public Task<List<AllergyPerson>> GetAllPersonAllergies(int personId)
        {
            return _allergyPersonRepository.GetAllPersonAllergies(personId);
        }
    }
}
