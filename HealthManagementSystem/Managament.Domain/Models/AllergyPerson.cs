using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class AllergyPerson
    {
        public int AllergyId { get; set; }

        [ForeignKey("AllergyId")]
        public virtual Allergy? Allergy { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        public DateTime DateDiscovered { get; set; }
    }
}
