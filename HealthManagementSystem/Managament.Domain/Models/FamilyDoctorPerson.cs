using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class FamilyDoctorPerson
    {
        public int FamilyDoctorId { get; set; }
        [ForeignKey("FamilyDoctorId")]
        public virtual FamilyDoctor? FamilyDoctor { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        public DateTime StartingDate { get; set; } = DateTime.Now;

        public DateTime EndingDate { get; set; }
    }
}
