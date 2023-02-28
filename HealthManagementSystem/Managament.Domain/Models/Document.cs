using System.ComponentModel.DataAnnotations;

namespace Management.Domain.Models
{
    public class Document
    {
        public Document()
        {
            LabResults = new HashSet<LabResult>();
        }

        [Key]
        public int DocumentId { get; set; }

        [StringLength(20, ErrorMessage = "Document name should be max 20 symbols long")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description should be max 20 symbols long")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }

        public virtual ICollection<LabResult> LabResults { get; set; }
    }
}
