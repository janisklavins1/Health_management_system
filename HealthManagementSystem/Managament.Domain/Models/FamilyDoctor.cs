using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class FamilyDoctor
    {
        [Key]
        public int FamilyDoctorId { get; set; }

        [ForeignKey("MedicalPractice")]
        [JsonIgnore]
        public int MedicalPracticeId { get; set; }
        public MedicalPractice? MedicalPractice { get; set; }

        [StringLength(50, ErrorMessage = "Place Of Education should be max 50 symbols long")]
        public string PlaceOfEducation { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Qualification should be max 50 symbols long")]
        public string Qualification { get; set; } = string.Empty;

        public DateTime JoiningDate { get; set; }

        [ForeignKey("Person")]
        [JsonIgnore]
        public int? PersonId { get; set; }
        public Person? Person { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
