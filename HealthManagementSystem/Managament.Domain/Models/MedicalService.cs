using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class MedicalService
    {
        [Key]
        public int MedicalServiceId { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        public ICollection<MedicalHistory>? MedicalHistories { get; set; }
    }
}
