using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class MedicalPractice
    {
        [Key]
        public int MedicalPracticeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string WebsiteUrl { get; set; } = string.Empty;

        [ForeignKey("PhoneNumber")]
        public int PhoneNumberId { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public ICollection<FamilyDoctor>? FamilyDoctors { get; set; }

    }
}
