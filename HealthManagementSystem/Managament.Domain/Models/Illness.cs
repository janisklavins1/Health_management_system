using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Illness
    {
        [Key]
        public int IllnessId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
