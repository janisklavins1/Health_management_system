using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class Medication
    {
        public Medication()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        [Key]
        public int MedicationId { get; set; }
        public string Name { get; set; } = string.Empty;
        [StringLength(200, ErrorMessage = "Code should be 4 symbols long")]
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
