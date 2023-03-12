using Management.Domain.Models;

namespace Management.Application.Dto
{
    public class IllnessPersonListDto
    {
        public int IllnessPersonId { get; set; }
        public Illness Illness { get; set; } = new Illness();
        public DateTime DateDiscovered { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Prohibitions { get; set; } = string.Empty;
    }
}
