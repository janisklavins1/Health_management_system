using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class Illness
    {
        [Key]
        public int IllnessId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 symbols long")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Max 200 symbols long")]
        public string Description { get; set; } = string.Empty;

        public ICollection<Person>? Persons { get; set; }
    }
}
