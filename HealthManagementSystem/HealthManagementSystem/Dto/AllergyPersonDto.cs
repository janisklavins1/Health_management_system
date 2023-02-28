using Management.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthManagementSystem.Dto
{
    public class AllergyPersonDto
    {
        public int AllergyId { get; set; }

        public int PersonId { get; set; }

        public DateTime DateDiscovered { get; set; }
    }
}
