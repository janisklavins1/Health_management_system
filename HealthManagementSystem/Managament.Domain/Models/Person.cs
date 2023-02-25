﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }

        [StringLength(100, ErrorMessage = "Name should be max 100 symbols long")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Surname should be max 100 symbols long")]
        public string Surname { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Gender should be max 20 symbols long")]
        public string Gender { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        [ForeignKey("PhoneNumber")]
        public int PhoneNumberId { get; set; }
        public PhoneNumber? PhoneNumber { get; set;}

        public ICollection<Allergy>? Allergies { get; set; }

    }
}