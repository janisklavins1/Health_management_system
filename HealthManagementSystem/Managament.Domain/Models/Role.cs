using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
