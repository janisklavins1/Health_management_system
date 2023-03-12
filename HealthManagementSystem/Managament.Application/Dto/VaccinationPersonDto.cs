namespace Management.Application.Dto
{
    public class VaccinationPersonDto
    {
        public int VaccinationId { get; set; }
        public int PersonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
