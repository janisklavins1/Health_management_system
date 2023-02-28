using Management.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IAllergyPersonService
    {
        Task<List<AllergyPerson>> GetAllPersonAllergies(int personId);
        Task AddAllergyToPerson(AllergyPerson allergyPerson);
    }
}
