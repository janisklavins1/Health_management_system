using Management.Domain.Models;

namespace Management.Application.Dto
{
    public class LabResultDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int PersonId { get; set; }
        public List<DocumentDto> Document { get; set; } = new List<DocumentDto>();
    }
}
