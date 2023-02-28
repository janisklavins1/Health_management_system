using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class LabResultStatus
    {
        [Key]
        public int LabResultStatusId { get; set; }

        [StringLength(200, ErrorMessage = "Max 200 symbols long")]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<LabResult>? LabResults { get; set; }
    }
}
