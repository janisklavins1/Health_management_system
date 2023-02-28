using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(10, ErrorMessage = "Role Title should be max 10 symbols long")]
        public string Title { get; set; } = string.Empty;

        public ICollection<Person>? Persons { get; set; }

    }
}
