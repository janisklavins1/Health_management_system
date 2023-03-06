using Management.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class Address
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [ForeignKey("City")]
        [Required]
        [JsonIgnore]
        public int CityId { get; set; }

        public City? City { get; set; }

        [ForeignKey("Country")]
        [Required]
        [JsonIgnore]
        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public string HouseAddress { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Max length is 10 symbols")]
        public string PostIndex { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }

        [JsonIgnore]
        public ICollection<Address>? Addresses { get; set; }
    }
}
