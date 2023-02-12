using Management.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("City")]
        [Required]
        public int CityId { get; set; }

        public virtual City? City { get; set; }

        [ForeignKey("Country")]
        [Required]
        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }

        public string HouseAddress { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Max length is 10 symbols")]
        public string PostIndex { get; set; } = string.Empty;
    }
}
