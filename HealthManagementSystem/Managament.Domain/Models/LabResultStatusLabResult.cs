using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Management.Domain.Models
{
    public class LabResultStatusLabResult
    {
        [Key]
        public int LabResultStatusLabResultId { get; set; }
        [JsonIgnore]
        public int LabResultId { get; set; }
        [ForeignKey("LabResultId")]
        [JsonIgnore]
        public virtual LabResult? LabResult { get; set; }
        [JsonIgnore]
        public int LabResultStatusId { get; set; }
        [ForeignKey("LabResultStatusId")]
        [JsonIgnore]
        public virtual LabResultStatus? LabResultStatus { get; set; }

        public DateTime Date { get; set; }
    }
}
