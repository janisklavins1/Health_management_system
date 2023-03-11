namespace Management.Application.Dto
{
    public class FamilyDoctorDto
    {
        public int MedicalPracticeId { get; set; }
        public string PlaceOfEducation { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}
