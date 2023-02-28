using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }

        public string Number { get; set; } = string.Empty;

        [ForeignKey("PhoneNumberCountryCode")]
        [StringLength(4, ErrorMessage = "Code should be 4 symbols long")]
        public int PhoneNumberCountryCodeId { get; set; }

        public PhoneNumberCountryCode? PhoneNumberCountryCode { get; set; }

        public ICollection<Person>? Persons { get; set; }

        public ICollection<MedicalPractice>? MedicalPractices { get; set; }
    }
}
