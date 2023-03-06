using Management.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthManagementSystem.Dto
{
    public class MedicationDto
    {
        public string Name { get; set; } = "Name";
        public string Description { get; set; } = "Description";
        public string Type { get; set; } = "Type";
        public virtual ICollection<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
    }
}
