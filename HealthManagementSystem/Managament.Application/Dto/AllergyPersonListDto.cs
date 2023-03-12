using Management.Domain.Models;

namespace Management.Application.Dto
{
    public class AllergyPersonListDto
    {
        public int AllergyPersonId { get; set; }
        public Allergy Allergy { get; set; } = new Allergy();
        public DateTime DateDiscovered { get; set; }
    }
}
