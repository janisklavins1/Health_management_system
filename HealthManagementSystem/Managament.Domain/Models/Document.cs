using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [StringLength(20, ErrorMessage = "Document name should be max 20 symbols long")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description should be max 20 symbols long")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string FilePath { get; set; } = string.Empty;

        
    }
}
