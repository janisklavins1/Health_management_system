﻿using Management.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management.Data.Models
{
    public class Country
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string CountryCode { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Address>? Address { get; set; }
    }
}
