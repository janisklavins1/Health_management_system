using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class TypeOfAllergy
    {
        [Key]
        public int TypeOfAllergyId { get; set; }

        [StringLength(100, ErrorMessage = "Allergy Type should be max 100 symbols long")]
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Allergy>? Allergies { get; set; }
    }
}
