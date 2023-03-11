using Management.Domain.Models;

namespace Management.Application.Dto
{
    public class MedicationPersonListDto
    {
        public int MedicationPersonId { get; set; }
        public Medication? Medication { get; set; }
        public DateTime StartingDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; } = new DateTime();
        public bool IsActive { get; set; }
    }
}
