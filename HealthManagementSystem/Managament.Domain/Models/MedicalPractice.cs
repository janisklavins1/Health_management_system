using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class MedicalPractice
    {
        [Key]
        public int MedicalPracticeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string WebsiteUrl { get; set; } = string.Empty;

        [ForeignKey("PhoneNumber")]
        [JsonIgnore]
        public int PhoneNumberId { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }

        [ForeignKey("Address")]
        [JsonIgnore]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        [JsonIgnore]
        public ICollection<FamilyDoctor>? FamilyDoctors { get; set; }
    }
}
