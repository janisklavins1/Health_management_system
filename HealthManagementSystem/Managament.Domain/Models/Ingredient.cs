using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Medications = new HashSet<Medication>();
        }

        [Key]
        [JsonIgnore]
        public int IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Medication> Medications { get; set; }

    }
}
