﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class Person
    {

        [Key]
        [JsonIgnore]
        public int PersonId { get; set; }

        [StringLength(100, ErrorMessage = "Name should be max 100 symbols long")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Surname should be max 100 symbols long")]
        public string Surname { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Gender should be max 20 symbols long")]
        public string Gender { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        [ForeignKey("Role")]
        [JsonIgnore]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("Address")]
        [JsonIgnore]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        [ForeignKey("PhoneNumber")]
        [JsonIgnore]
        public int PhoneNumberId { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }

        [JsonIgnore]
        public ICollection<Allergy>? Allergies { get; set; }

        [JsonIgnore]
        public ICollection<FamilyDoctor>? FamilyDoctors { get; set; }

        [JsonIgnore]
        public ICollection<Illness>? Illnesses { get; set; }

        [JsonIgnore]
        public ICollection<Medication>? Medications { get; set; }

        [JsonIgnore]
        public ICollection<Vaccination>? Vaccinations { get; set; }

        [JsonIgnore]
        public ICollection<LabResult>? LabResults { get; set; }
    }
}
