using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class VaccinationPerson
    {
        public int VaccinationId { get; set; }
        [ForeignKey("VaccinationId")]
        public virtual Vaccination? Vaccination { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        public int MedicalPracticeId { get; set; }
        [ForeignKey("MedicalPracticeId")]
        public virtual MedicalPractice? MedicalPractice { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
