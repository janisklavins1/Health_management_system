using Management.Domain.Models;

namespace Management.Application.Dto
{
    public class LabResultListDto
    {
        public int LabResultId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<Document> Document { get; set; } = new List<Document>();
        public ICollection<LabResultStatusDto> LabResultStatuses { get; set; } = new List<LabResultStatusDto>();
    }
}
