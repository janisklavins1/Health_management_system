using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class Allergy
    {
        [Key]
        public int AllergyId { get; set; }

        [StringLength(100, ErrorMessage = "Allergy Name should be max 100 symbols long")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("TypeOfAllergy")]
        [JsonIgnore]
        public int TypeOfAllergyId { get; set; }
        [JsonIgnore]
        public TypeOfAllergy? TypeOfAllergies { get; set; }

        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }
    }
}
