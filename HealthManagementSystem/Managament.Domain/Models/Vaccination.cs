using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Vaccination
    {
        [Key]
        public int VaccinationId { get; set; }

        [StringLength(200, ErrorMessage = "Max 200 symbols long")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Person>? Persons { get; set; }
    }
}
