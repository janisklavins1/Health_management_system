using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class MedicalHistory
    {
        [Key]
        public int MedicalHistoryId { get; set; }

        [Required]
        public DateTime RegisteredDate { get; set; }

        //[ForeignKey("FamilyDoctor")]
        //public int FamilyDoctorId { get; set; }
        //public FamilyDoctor? FamilyDoctor { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        [ForeignKey("MedicalService")]
        public int MedicalServiceId { get; set; }
        public MedicalService? MedicalService { get; set; }
    }
}
