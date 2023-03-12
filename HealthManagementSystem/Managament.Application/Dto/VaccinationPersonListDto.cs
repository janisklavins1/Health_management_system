using Management.Domain.Models;

namespace Management.Application.Dto
{
    public class VaccinationPersonListDto
    {
        public int VaccinationPersonId { get; set; }
        public Vaccination Vaccination { get; set; } = new Vaccination();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
