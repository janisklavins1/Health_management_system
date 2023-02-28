using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Medications = new HashSet<Medication>();
        }

        [Key]
        [JsonIgnore]
        public int IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Medication> Medications { get; set; }

    }
}
