using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class LabResult
    {
        public LabResult()
        {
            Documents = new HashSet<Document>();
        }

        [Key]
        public int LabResultId { get; set; }


        [StringLength(1000, ErrorMessage = "Description should be max 1000 symbols long")]
        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<LabResultStatus> LabResultStatuses { get; set; }
    }
}
