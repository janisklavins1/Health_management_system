using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class FamilyDoctor
    {
        [Key]
        public int FamilyDoctorId { get; set; }

        [ForeignKey("MedicalPractice")]
        public int MedicalPracticeId { get; set; }
        public MedicalPractice? MedicalPractice { get; set; }

        [StringLength(50, ErrorMessage = "Place Of Education should be max 50 symbols long")]
        public string PlaceOfEducation { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Qualification should be max 50 symbols long")]
        public string Qualification { get; set; } = string.Empty;

        public DateTime JoiningDate { get; set; }

        public ICollection<Person>? Persons { get; set; }
    }
}
