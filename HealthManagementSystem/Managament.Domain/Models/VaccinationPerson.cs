using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class VaccinationPerson
    {
        [Key]
        public int VaccinationPersonId { get; set; }

        [JsonIgnore]
        public int VaccinationId { get; set; }
        [ForeignKey("VaccinationId")]
        public virtual Vaccination? Vaccination { get; set; }

        [JsonIgnore]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        [JsonIgnore]
        public int MedicalPracticeId { get; set; }
        [ForeignKey("MedicalPracticeId")]
        public virtual MedicalPractice? MedicalPractice { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
