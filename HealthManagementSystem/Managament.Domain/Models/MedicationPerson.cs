using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class MedicationPerson
    {
        [Key]
        public int MedicationPersonId { get; set; }

        public int MedicationId { get; set; }
        [ForeignKey("MedicationId")]
        public virtual Medication? Medication { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        public bool IsActive { get; set; }
    }
}
