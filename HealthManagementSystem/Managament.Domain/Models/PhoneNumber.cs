using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class PhoneNumber
    {
        [Key]
        [JsonIgnore]
        public int PhoneNumberId { get; set; }

        public string Number { get; set; } = string.Empty;

        [ForeignKey("PhoneNumberCountryCode")]
        [StringLength(4, ErrorMessage = "Code should be 4 symbols long")]
        [JsonIgnore]
        public int PhoneNumberCountryCodeId { get; set; }

        public PhoneNumberCountryCode? PhoneNumberCountryCode { get; set; }

        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }

        [JsonIgnore]
        public ICollection<MedicalPractice>? MedicalPractices { get; set; }
    }
}
