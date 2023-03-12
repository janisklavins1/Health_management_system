namespace Management.Application.Dto
{
    public class IllnessPersonEditDto
    {
        public int IllnessId { get; set; }
        public int PersonId { get; set; }
        public DateTime DateDiscovered { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Prohibitions { get; set; } = string.Empty;
    }
}
