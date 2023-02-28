using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Domain.Models
{
    public class IllnessPerson
    {
        public int IllnessId { get; set; }
        [ForeignKey("IllnessId")]
        public virtual Illness? Illness { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }

        public DateTime DateDiscovered { get; set; }

        [StringLength(20, ErrorMessage = "Max 20 symbols long")]
        public string Status { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Max 200 symbols long")]
        public string Prohibitions { get; set; } = string.Empty;
    }
}
