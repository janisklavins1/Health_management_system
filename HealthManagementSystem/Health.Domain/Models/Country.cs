using System.ComponentModel.DataAnnotations;

namespace Health.Domain.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string CountryCode { get; set; } = string.Empty;
    }
}
