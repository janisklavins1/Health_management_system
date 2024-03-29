﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class Vaccination
    {
        [Key]
        public int VaccinationId { get; set; }

        [StringLength(200, ErrorMessage = "Max 200 symbols long")]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }
    }
}
