using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class LabResultStatusLabResult
    {
        [Key]
        public int LabResultStatusLabResultId { get; set; }

        public int LabResultId { get; set; }
        [ForeignKey("LabResultId")]
        public virtual LabResult? LabResult { get; set; }

        public int LabResultStatusId { get; set; }
        [ForeignKey("LabResultStatusId")]
        public virtual LabResultStatus? LabResultStatus { get; set; }

        public DateTime Date { get; set; }
    }
}
