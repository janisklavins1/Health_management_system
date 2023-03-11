using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class Role
    {
        [Key]
        [JsonIgnore]
        public int RoleId { get; set; }

        [StringLength(10, ErrorMessage = "Role Title should be max 10 symbols long")]
        public string Title { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }

    }
}
