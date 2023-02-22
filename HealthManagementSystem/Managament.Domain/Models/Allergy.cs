using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int TypeOfAllergyId { get; set; } 
        public TypeOfAllergy? TypeOfAllergies { get; set; }

        public ICollection<Person>? Persons { get; set; }
    }
}
