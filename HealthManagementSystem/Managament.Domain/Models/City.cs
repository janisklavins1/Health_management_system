using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class City
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Address>? Address { get; set; }
    }
}
