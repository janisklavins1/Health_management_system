using System.ComponentModel.DataAnnotations.Schema;

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
