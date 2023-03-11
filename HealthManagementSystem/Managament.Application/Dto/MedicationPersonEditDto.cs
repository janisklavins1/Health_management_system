namespace Management.Application.Dto
{
    public class MedicationPersonEditDto
    {
        public int MedicationId { get; set; }
        public int PersonId { get; set; }
        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; } = new DateTime();
        public bool IsActive { get; set; } = true;
    }
}
