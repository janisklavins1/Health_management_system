using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class PhoneNumberCountryCode
    {
        [Key]
        [JsonIgnore]
        public int PhoneNumberCountryCodeId { get; set; }


        public string Code { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<PhoneNumber>? PhoneNumber { get; set; }
    }
}
