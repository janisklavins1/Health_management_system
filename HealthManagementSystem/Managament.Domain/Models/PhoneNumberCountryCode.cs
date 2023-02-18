using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class PhoneNumberCountryCode
    {
        [Key]
        public int PhoneNumberCountryCodeId { get; set; }


        public string Code { get; set; } = string.Empty;
        public ICollection<PhoneNumber>? PhoneNumber { get; set; }
    }
}
