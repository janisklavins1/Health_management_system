using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Address>? Address { get; set; }
    }
}
